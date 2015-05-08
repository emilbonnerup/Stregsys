namespace Stregsystem
{
    public interface IStregsystemUI
    {
        void DisplayUserNotFound(User user);
        void DisplayProductNotFound(Product product);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundMessage();
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(BuyTransaction transaction);
        void DisplayGeneralError(string errorString);
    }
}