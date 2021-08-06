namespace CardApi.DTOs.User
{
    public static class UserExtension
    {
        public static UserDTO ToDTO(this Model.User user)
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

        public static Model.User ToModel(this UserDTO user)
        {
            return user == null ?
                null :
                new Model.User
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email                   
                };
        }
    }
}
