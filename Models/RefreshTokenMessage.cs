using CommunityToolkit.Mvvm.Messaging.Messages;

namespace NewsApplication.Models {
    public class RefreshTokenMessage : ValueChangedMessage<string> {
        public RefreshTokenMessage(string value) : base(value) {
        }
    }
}
