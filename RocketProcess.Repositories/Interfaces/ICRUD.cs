using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Interfaces
{
    public interface ICRUD<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<PostResponse> Create(T Modelo);
        public Task<IEnumerable<T>> Read(int Id);
        public Task<IEnumerable<T>> Read(string Id);
        public Task<PostResponse> Update(T Modelo);
        public Task<PostResponse> Delete(int Id);
        public Task<PostResponse> Delete(string Id);
    }
}
