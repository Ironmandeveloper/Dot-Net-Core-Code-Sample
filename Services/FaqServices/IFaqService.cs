using DataModels.Models;
using DataModels.Models.Faq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FaqServices
{
    public interface IFaqService
    {
        Task<List<Faq>> GetFaqs();
        Task<bool> AlreadyExists(string Question);
        Task<string> Create(Faq faq);
        Task<Faq> GetFaqById(int Id);
        Task<string> Update(Faq faq);
        Task<string> Delete(int Id);
    }
}
