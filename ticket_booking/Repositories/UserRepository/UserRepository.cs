//using cho_nong_san.Data;
//using Microsoft.EntityFrameworkCore;

//namespace cho_nong_san.Repositories.UserRepository
//{
//    public class UserRepository : IUserRepository
//    {
//        public readonly MyDBContext myDBContext;

//        public UserRepository(MyDBContext myDBContext)
//        {
//            this.myDBContext = myDBContext;
//        }

//        public List<User> GetAll()
//        {
//            return myDBContext.Users.ToList();
//        }

//        public IResult Login(string email, string password)
//        {
//            User user = myDBContext.Users.Include(user => user.Role).FirstOrDefault(user => user.Email == email);
//            if(user == null) { return Results.NotFound("user khong ton tai"); }
//            if (user.Password != password) { return Results.Conflict("mat khau khong khop"); };
            
//            return Results.Ok(user);
//        }
//    }
//}
