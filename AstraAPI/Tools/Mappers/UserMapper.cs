using Astra.DAL.Entities;
using AstraAPI.Models.User;

namespace AstraAPI.Tools.Mappers
{
    public static class UserMapper
    {
            public static ConnectedUserDTO ToDto(this UserEntity e)
            {
                if (e is not null)
                {
                    return new ConnectedUserDTO
                    {
                        Id = e.Id,
                        Pseudo = e.Pseudo,
                        Email = e.Email,
                        IsAdmin = e.IsAdmin
                    };
                }
                return null;
            }

        public static SearchUserDTO ToDtoSearch(this UserEntity e)
        {
            if (e is not null)
            {
                return new SearchUserDTO
                {
                    Id = e.Id,
                    Pseudo = e.Pseudo
                };
            }
            return null;
        }
    }
}
