
//using Exadel.Data;
//using Exadel.Requests;

//public class JwtService
//{
//    private readonly BooksContext _booksContext;
//    private readonly IConfiguration _configuration;

//    public JwtService(BooksContext booksContext, IConfiguration configuration)
//    {
//        _booksContext = booksContext;
//        _configuration = configuration;
//    }

//    public async Task <LoginResponse?> Authenticate(LoginRequest request)
//    {
//        if(string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
//            return null;
//         var userAccount = await _booksContext.UserAccounts.
//    } 
//}