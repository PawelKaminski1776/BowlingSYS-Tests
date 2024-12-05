namespace BowlingSys.Entities.UserDBEntities
{
    public class GetUserIDResult
    {
        public Guid User_Id { get; set; }
    }

    public class GetLoginResult 
    {
        public bool Active { get; set; }
    }

    public class ErrorMessage 
    {
        public string message { get; set; }
    }
}
