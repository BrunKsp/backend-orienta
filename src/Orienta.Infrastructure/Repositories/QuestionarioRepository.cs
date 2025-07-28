using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orienta.Domain.Entities;
using Orienta.Infrastructure.Persistence;

namespace Orienta.Infrastructure.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        private readonly OrientaDbContext _context;

        public QuestionarioRepository(OrientaDbContext context)
        {
            _context = context;
        }

        public async Task SalvarAsync(QuestionarioEntity questionario)
        {
            await _context.Questionarios.AddAsync(questionario);
            await _context.SaveChangesAsync();
        }
    }
}