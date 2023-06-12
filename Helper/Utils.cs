namespace NewsApplication.Helper {
    public static class Utils {
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }

        public static DateTime RefreshTokenExpiresIn { get; set; }
    }
}
