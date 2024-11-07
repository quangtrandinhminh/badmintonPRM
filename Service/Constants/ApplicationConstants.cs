namespace Service.Constants
{
    public class ResponseCodeConstants
    {
        public const string NOT_FOUND = "Not found!";
        public const string BAD_REQUEST = "Bad request!";
        public const string SUCCESS = "Success!";
        public const string FAILED = "Failed!";
        public const string EXISTED = "Existed!";
        public const string DUPLICATE = "Duplicate!";
        public const string INTERNAL_SERVER_ERROR = "INTERNAL_SERVER_ERROR";
        public const string INVALID_INPUT = "Invalid input!";
        public const string UNAUTHORIZED = "Unauthorized!";
        public const string FORBIDDEN = "Forbidden!";
        public const string EXPIRED = "Expired!";
        public const string CONFLICT = "Conflict!";
    }
    public class ResponseMessageConstantsCommon
    {
        public const string NOT_FOUND = "Data NotFound!";
        public const string EXISTED = "Already existed!";
        public const string SUCCESS = "Success!";
        public const string NO_DATA = "No data";
        public const string SERVER_ERROR = "Internal Server Error";
    }

    public class UserMessageConstants
    {
        public const string USER_UNAUTHORIZED = "Username or password not correct!";
        public const string USER_NOT_FOUND = "User not found!";
        public const string USER_EXISTED = "User existed!";
        public const string USER_SUCCESS = "User success!";
        public const string USER_NO_DATA = "User no data";
        public const string USER_REGISTER_SUCCESS = "Register success!";
        public const string USER_AUTHENTICATE_SUCCESS = "Authenticate success!";
        public const string USER_CONFLICT = "User conflict!";
    }

    public class ProductMessageConstants
    {
        public const string PRODUCT_NOT_FOUND = "Product not found!";
        public const string PRODUCT_EXISTED = "Product existed!";
        public const string PRODUCT_SUCCESS = "Product success!";
        public const string PRODUCT_NO_DATA = "Product no data";
    }

    public class CategoryMessageConstants
    {
        public const string CATEGORY_NOT_FOUND = "Category not found!";
        public const string CATEGORY_EXISTED = "Category existed!";
        public const string CATEGORY_SUCCESS = "Category success!";
        public const string CATEGORY_NO_DATA = "Category no data";
    }
}