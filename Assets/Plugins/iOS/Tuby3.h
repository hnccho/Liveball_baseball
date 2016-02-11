#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern UIViewController *UnityGetGLViewController();
//extern "C" void UnitySendMessage(const char *, const char *, const char *);

@interface IOSMgr : UIViewController<UINavigationControllerDelegate, UIImagePickerControllerDelegate>{
    UIImagePickerController *imagePicker;
}
@property (retain)UIImagePickerController *imagePicker;

+ (IOSMgr*)sharedInstance;
- (id)init;
- (void)dealloc;
- (void)imagePickerController:(UIImagePickerController *)picker didFinishPickingMediaWithInfo:(NSDictionary *)info;
- (void)imagePickerControllerDidCancel:(UIImagePickerController *)picker;

@end