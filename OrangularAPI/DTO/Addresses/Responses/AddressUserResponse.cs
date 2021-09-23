using OrangularAPI.Helpers;

namespace OrangularAPI.DTO.Addresses.Responses
{
    public class AddressUserResponse
    {
        public int userID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

    }
}
