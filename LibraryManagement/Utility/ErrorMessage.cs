namespace LibraryManagement.Utility
{
    public static class ErrorMessage
    {
        public const string RegisterSuccess = "Registration  successfully!";
        public const string LoginSuccess = "Login successful!";

        // ------------------ Error Messages ------------------
        public const string InvalidUserData = "User data cannot be empty.";
        public const string EmailAlreadyExists = "Registration failed. This email is already registered.";
        public const string RegisterFailed = "Registration failed, please try again.";
        public const string InvalidCredentials = "Invalid email or password!";
        public const string ServerError = "Something went wrong on the server. Please try again later.";
    }
}
