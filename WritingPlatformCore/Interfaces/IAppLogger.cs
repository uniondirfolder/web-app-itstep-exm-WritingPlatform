using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatformCore.Interfaces
{
    /// <summary>
    /// Цей тип усуває необхідність безпосередньо залежати від типів ведення журналу ASP.NET Core.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
