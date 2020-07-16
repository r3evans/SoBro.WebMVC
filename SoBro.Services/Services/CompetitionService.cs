using SoBro.Data;
using SoBro.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Services.Services
{
    public class CompetitionService
    {
        private readonly Guid _userId;

        public CompetitionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCompetition(CompetitionCreate model)
        {
            var entity =
                new Competition()
                {

                    Name = model.Name,
                    City = model.City,
                    Ranked = model.Ranked
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Competitions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CompetitionListItem> GetCompetition()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Competitions
                        .Select(
                            e =>
                                new CompetitionListItem
                                {
                                    Name = e.Name,
                                    Ranked = e.Ranked,
                                    City = e.City
                                }
                        );

                return query.ToArray();
            }
        }

        public CompetitionDetail GetCompetitionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Competitions
                        .Single(e => e.CompetitionId == id);
                return
                    new CompetitionDetail
                    {
                        CompetitionId = entity.CompetitionId,
                        Name = entity.Name,
                        City = entity.City,
                        Ranked = entity.Ranked

                    };
            }

        }
    }
}
