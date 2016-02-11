#import "TubyIAP.h"
#import "Tuby3.h"

BOOL isInit;

extern "C"
{
    void iOSInAppInit(const char* pszProductIds)
    {
        NSString* strProductIds = [NSString stringWithUTF8String:pszProductIds];
        [[TubyIAP sharedTubyIAP] initInApp:strProductIds];
    }
    void iOSBuyItem(const char* pszProductId)
    {
        NSString* strProductId = [NSString stringWithUTF8String:pszProductId];
        [[TubyIAP sharedTubyIAP] requestProductData:strProductId];
    }
    void iOSRestoreCompletedTransactions()
    {
        [[TubyIAP sharedTubyIAP] restoreCompletedTransactions];
    }
}

@implementation TubyIAP

+ (TubyIAP*) sharedTubyIAP
{
    static TubyIAP* pInstance;
    if(pInstance == NULL)
    {
        pInstance = [[TubyIAP alloc] init];
    }
    return pInstance;
}

- (BOOL) initInApp:(NSString*)strProductIds
{
    if( [SKPaymentQueue canMakePayments] == NO ){
        UnitySendMessage("IOSMgr", "MsgReceived", "NO");
        return NO;
    }
    
//    isInit = true;
    
    [[SKPaymentQueue defaultQueue] addTransactionObserver:self];
    
    NSLog(@"InAppPurchase init OK");
//    UnitySendMessage("IOSMgr", "MsgReceived", "OK");
//    NSArray *prodList = [strProductIds componentsSeparatedByString:@";"];
//    NSSet* productIdentifiers = [NSSet setWithArray:prodList];
//    SKProductsRequest* request = [[SKProductsRequest alloc] initWithProductIdentifiers:productIdentifiers];
//    request.delegate = self;
//    [request start];
    
    return true;
}

///< 아이템 정보 요청
- (void) requestProductData:(NSString*)strProductId
{
    ///< iTunes Connect에 설정한 Product ID들
    NSSet* productIdentifiers = [NSSet setWithObject:strProductId];
    SKProductsRequest* request = [[SKProductsRequest alloc] initWithProductIdentifiers:productIdentifiers];
    request.delegate = self;
    [request start];
    NSLog(@"requestProductData %@", strProductId);
}

///< 아이템 정보 요청 결과 callback
- (void) productsRequest:(SKProductsRequest *)request didReceiveResponse:(SKProductsResponse *)response
{
    NSMutableArray *prodKeys = [[NSMutableArray alloc] init];
    NSMutableArray *prodPrices = [[NSMutableArray alloc] init];
    NSLog( @"InAppPurchase didReceiveResponse" );
    for( SKProduct* product in response.products )
    {
        if( product != nil )
        {
            NSLog(@"InAppPurchase Product title: %@", product.localizedTitle);
            NSLog(@"InAppPurchase Product description: %@", product.localizedDescription);
            NSLog(@"InAppPurchase Product price: %@", product.price);
            //product.priceLocale
            NSLog(@"InAppPurchase Product id: %@", product.productIdentifier);
            
            if(isInit){
                [prodKeys addObject:product.productIdentifier];
                [prodPrices addObject:[product.price stringValue]];
            } else{
                ///< 구매 요청
                SKPayment* payment = [SKPayment paymentWithProduct:product];
                //payment.quantity = 10;
                [[SKPaymentQueue defaultQueue] addPayment:payment];
            }
        }
    }
    if(isInit){
        NSDictionary *dics = [[NSDictionary alloc] initWithObjects:prodPrices forKeys:prodKeys];
        NSData *jsonData = [NSJSONSerialization dataWithJSONObject:dics options:0 error:nil];
        NSString *tmp = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
        UnitySendMessage("IOSMgr", "MsgReceived", [tmp UTF8String]);
    }
    isInit = false;
    [request release];
    
    for (NSString *invalidProductId in response.invalidProductIdentifiers)
    {
        NSLog(@"InAppPurchase Invalid product id: %@", invalidProductId);
    }
}

///< 새로운 거래가 발생하거나 갱신될 때 호출된다.
- (void) paymentQueue:(SKPaymentQueue *)queue updatedTransactions:(NSArray *)transactions
{
    for (SKPaymentTransaction *transaction in transactions)
    {
        switch (transaction.transactionState)
        {
                ///< 서버에 거래 처리중
            case SKPaymentTransactionStatePurchasing:
                NSLog(@"InAppPurchase SKPaymentTransactionStatePurchasing");
                break;
                ///< 구매 완료
            case SKPaymentTransactionStatePurchased:
                [self completeTransaction:transaction];
                break;
                ///< 거래 실패 또는 취소
            case SKPaymentTransactionStateFailed:
                [self failedTransaction:transaction];
                break;
                ///< 재구매
            case SKPaymentTransactionStateRestored:
                [self restoreTransaction:transaction];
                break;
        }
    }
}

- (void) completeTransaction:(SKPaymentTransaction *)transaction
{
    NSLog(@"InAppPurchase completeTransaction");
    NSLog(@"InAppPurchase Transaction Identifier : %@", transaction.transactionIdentifier );
    NSLog(@"InAppPurchase Transaction Date : %@", transaction.transactionDate );
    ///< 구매 완료 후 아이템 인벤등 게임쪽 후 처리 진행
    /* 빌트 인 모델
     const char* pszProductId = [[[transaction payment] productIdentifier] UTF8String];
     UnitySendMessage("IOSMgr", "ResultBuyItem", pszProductId);
     */
    NSString* strReceipt = [[NSString alloc] initWithBytes:transaction.transactionReceipt.bytes length:transaction.transactionReceipt.length encoding:NSUTF8StringEncoding];
    
    UnitySendMessage("IOSMgr", "PurchaseSucceeded", [strReceipt UTF8String]);
    
    // Remove the transaction from the payment queue.
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
}

- (void) restoreTransaction:(SKPaymentTransaction *)transaction
{
    NSLog(@"InAppPurchase restoreTransaction");
    const char* pszRestoreProductId = [transaction.originalTransaction.payment.productIdentifier UTF8String];
    UnitySendMessage("IOSMgr", "ResultRestoreItem", pszRestoreProductId);
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
}

- (void) failedTransaction:(SKPaymentTransaction *)transaction
{
    NSLog(@"InAppPurchase failedTransaction.");
    const char* pszResult = 0;
    if( transaction.error.code != SKErrorPaymentCancelled )
    {
        pszResult = "failedIAP";
        NSLog(@"InAppPurchase failedTransaction SKErrorDomain - %d", transaction.error.code );
    }
    else
    {
        pszResult = "cancelIAP";
        NSLog(@"InAppPurchase failedTransaction SKErrorPaymentCancelled");
    }
    UnitySendMessage("IOSMgr", "PurchaseFailed", pszResult);
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
}

// 비소모성 아이템 복원 요청
- (void) restoreCompletedTransactions
{
    [[SKPaymentQueue defaultQueue] restoreCompletedTransactions];
}

@end