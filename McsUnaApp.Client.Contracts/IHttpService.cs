using System.Collections.Generic;
using System.Threading.Tasks;

namespace McsUnaApp.Client.Contracts
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        Task<T> LoginAsync<T>(string uri, object value);
        Task<IEnumerable<T>> GetEntities<T>(string uri);
        Task<IEnumerable<T>> GetFilteredEntities<T>(string uri, object value);
    }
}