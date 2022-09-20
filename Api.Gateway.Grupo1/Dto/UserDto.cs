﻿namespace Api.Gateway.Grupo1.Dto
{
    public class UserDto
    {

        public int id { get; set; }
        
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public List<PostDto> posts { get; set; }=new List<PostDto>();
    }
}
