using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BrowserGame.DataAccessLayer.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlanetId { get; set; }
    }
}
