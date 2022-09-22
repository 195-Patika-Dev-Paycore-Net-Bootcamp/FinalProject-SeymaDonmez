using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycoreFinalProject.Service.Constants
{
    public static class Messages
    {
        public static string UserEmailFormatErrorMassage = "Please enter a valid email address";
        public static string FirstNameErrorMessage = "First name field cannot be null or empty.";
        public static string LastNameErrorMessage = "Last name field cannot be null or empty.";
        public static string EmailOrPasswordError = "Please validate your informations that you provided.";
        public static string SuccessfulLogin = "Successfully logged in";
        public static string UserRegistered = "User registered successfully";
        public static string UserValidationError = "Please fill in the requested information completely.";
        public static string UserExists = "User already exists.";


        public static string ProductInvalid = "Please enter a valid product";

        public static string ProductNameInvalid = "Please enter a valid product name";
        public static string ProductCategoryError = "Category number is required";
        public static string ProductColorError = "Product color is required";
        public static string ProductBrandError = "Product brand is required";
        public static string ProductPriceError = "Product price is required";


        public static string ProductDescriptionError = "Please enter a description";


    }
}
