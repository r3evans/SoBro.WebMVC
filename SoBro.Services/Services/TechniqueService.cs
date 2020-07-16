using SoBro.Data;
using SoBro.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBro.Services.Services
{
    public class TechniqueService
    {
        private readonly Guid _userId;

        public TechniqueService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTechnique(TechniqueCreate model)
        {
            var entity =
                new Technique()
                {
                    
                    Name = model.Name,
                    Description = model.Description,
                    Difficulty = model.Difficulty
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Techniques.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public TechniqueDetail GetTechniqueById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Techniques
                        .Single(e => e.TechniqueId == id);
                return
                    new TechniqueDetail
                    {
                        TechniqueId = entity.TechniqueId,
                        Name = entity.Name,
                        Difficulty = entity.Difficulty,
                        Description = entity.Description
                        
                    };
            }
        }

        public IEnumerable<TechniqueListItem> GetTechnique()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Techniques
                        .Select(
                            e =>
                                new TechniqueListItem
                                {
                                    Name = e.Name,
                                    Description = e.Description,
                                    RequiresGi = e.RequiresGi,
                                    Difficulty = e.Difficulty  
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateTechnique(TechniqueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Techniques
                        .Single(e => e.TechniqueId == model.TechniqueId);

                entity.Name = model.Name;
                entity.Difficulty = model.Difficulty;
                entity.Description = model.Description;
                return ctx.SaveChanges() == 1;
            }

        }


    }
}

