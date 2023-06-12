using CommunityToolkit.Mvvm.Messaging.Messages;

namespace NewsApplication.Models {
    public class RefreshTokenExpireMessage : ValueChangedMessage<string> {
        public RefreshTokenExpireMessage(string value) : base(value) {

        }
    }
}
