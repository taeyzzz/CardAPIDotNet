namespace Application.DTOs.User
{
    public static class UserExtension
    {
        public static UserDTO ToDTO(this Domain.Entities.User user)
        {
            return user == null ?
                null :
                new UserDTO
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email
                };
        }
    }
}
