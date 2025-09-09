using DocumentStorage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStorage.Application.Interfaces.Repositories
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
