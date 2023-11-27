using DataModels.DAL;
using DataModels.Models;
using DataModels.Models.Faq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FaqServices
{
    public class ChatService : IFaqService
    {
        private readonly ApplicationDBContext _context;
        public ChatService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AlreadyExists(string Question)
        {
            if (await _context.Faqs.Where(x => x.Question == Question).CountAsync() > 0)
            {
                return true;
            }
            else { return false; }
        }

      
        public async Task<string> Create(Faq faq)
        {
            await _context.Faqs.AddAsync(faq);
            await _context.SaveChangesAsync();
            return "Faq has been added successfully";
        }
        public async Task<string> Delete(int Id)
        {
            var faq = await _context.Faqs.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
            if (faq == null)
            {
                return "faq doesn't exists";
            }
            _context.Faqs.Remove(faq);
            await _context.SaveChangesAsync();
            return "faq has been deleted Successfully";
        }
        public async Task<Faq> GetFaqById(int Id)
        {
            var Faq = await _context.Faqs.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (Faq == null)
            {
                return new Faq();
            }
            else
            {
                return Faq;
            }
        }

        public async Task<List<Faq>> GetFaqs()
        {
            if(await _context.Faqs.AnyAsync())
            {
                return await _context.Faqs.ToListAsync();
            }
            return new List<Faq>();
        }
        public async Task<string> Update(Faq faq)
        {
            var Faq = await _context.Faqs.Where(x => x.Id == faq.Id).FirstOrDefaultAsync();
            if (Faq == null)
            {
                return "Product type doesn't exists";
            }
            Faq.Question = faq.Question;
            Faq.Answer = faq.Answer;
            Faq.IsActive = faq.IsActive;
            _context.Faqs.Update(Faq);
            await _context.SaveChangesAsync();
            return "faq has been updated successfully";
        }
    }
}

