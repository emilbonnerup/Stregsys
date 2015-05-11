namespace Stregsystem
{
    interface IStregsystemUi
    {
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(int id);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundMessage();
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(BuyTransaction transaction);
        void DisplayGeneralError(string errorString);
    }
}