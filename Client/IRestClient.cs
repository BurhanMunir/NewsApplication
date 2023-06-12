namespace NewsApplication.Client {
    public interface IRestClient {
        public  Task<string> GenTokenAsync();
        public Task<string> RefreshToken();
        public Task<string> GetAsync(string url);

        public Task GetUserInfo();
    }
}
