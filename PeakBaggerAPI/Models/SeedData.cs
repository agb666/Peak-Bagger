using Microsoft.EntityFrameworkCore;
using PeakBaggerAPI.Data;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Console.WriteLine("SaveChangesFailedEventArgs Data...");
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {

                context.Database.EnsureCreated();


                var tag = new Tag[]
               {
                    new Tag {Name = "Trail 100 2022"}
               };

                if (!context.Tags.Any())
                {
                    foreach (Tag t in tag)
                    {
                        context.Tags.Add(t);
                    }
                }

                var countries = new Country[]
                {
                    new Country {Name = "England"},
                    new Country {Name = "Scotland"},
                    new Country {Name = "Wales"},
                    new Country {Name = "Northen Ireland"}
                };

                if (!context.Countries.Any())
                {
                    foreach (Country c in countries)
                    {
                        context.Countries.Add(c);
                    }
                }

                context.SaveChanges();


                var areas = new Area[]
                {
                  new Area {Name = "Peak District", CountryId = countries.Single(c => c.Name == "England").Id },
                  new Area {Name = "Lake District", CountryId = countries.Single(c => c.Name == "England").Id },
                  new Area {Name = "Northern Pennines", CountryId = countries.Single(c => c.Name == "England").Id },
                  new Area {Name = "Yorkshire Dales", CountryId = countries.Single(c => c.Name == "England").Id },
                  new Area {Name = "North York Mores", CountryId = countries.Single(c => c.Name == "England").Id },
                  new Area {Name = "Dartmore", CountryId = countries.Single(c => c.Name == "England").Id }
                };

                if (!context.Areas.Any())
                {
                    foreach (Area a in areas)
                    {
                        context.Areas.Add(a);
                    }
                };

                context.SaveChanges();

                var peaks = new Peak[]
                    {
                  new Peak {Name = "Kinder Scout", Height = "12345M", LoactionRefernce ="123456", Description ="",
                            AreaId = areas.Single(c => c.Name == "Peak District").Id, TagId =  tag.Single(c => c.Name == "Trail 100 2022").Id},
                  new Peak {Name = "Kinder Scout Low", Height = "12345M", LoactionRefernce ="6786", Description ="",
                            AreaId = areas.Single(c => c.Name == "Peak District").Id, TagId =  tag.Single(c => c.Name == "Trail 100 2022").Id},
                    new Peak {Name = "Birchen Edge", Height = "123M", LoactionRefernce ="2323", Description ="",
                            AreaId = areas.Single(c => c.Name == "Peak District").Id, TagId =  tag.Single(c => c.Name == "Trail 100 2022").Id}

                    };
                if (!context.Peaks.Any())
                {
                    foreach (Peak p in peaks)
                    {
                        context.Peaks.Add(p);
                    }
                };
                context.SaveChanges();

                var bagged = new Bagged[]
                {
                  new Bagged {Date = (Convert.ToDateTime("25/05/2022 12:10:00 PM") ), Comments = "Another Nice Day", PeakId = peaks.Single(c => c.Name == "Kinder Scout").Id },
                  new Bagged {Date = (Convert.ToDateTime("25/05/2022 12:35:00 PM") ), Comments = "Nice Day", PeakId = peaks.Single(c => c.Name == "Kinder Scout Low").Id },
                  new Bagged {Date = (Convert.ToDateTime("25/01/2022 01:00:00 PM") ), Comments = "Nice Day", PeakId = peaks.Single(c => c.Name == "Kinder Scout Low").Id },
                  new Bagged {Date = (Convert.ToDateTime("01/06/2022 02:15:15 PM") ), Comments = "Nice Day", PeakId = peaks.Single(c => c.Name == "Kinder Scout").Id }
                };
                if (!context.Bagged.Any())
                {
                    foreach (Bagged b in bagged)
                    {
                        context.Bagged.Add(b);
                    }
                };
                context.SaveChanges();


                var trigPointType = new TrigPointType[]
                {
                    new TrigPointType {Name = "Pillar",
                        Description ="The classic trigpoint and a welcome sight for hill walkers everywhere! A concrete pillar about 4' high, with a flush bracket near the base and a circular plate on top with groves for mounting a theodolite. There are 6874 pillars listed in the T:UK database. Whilst most of them have fallen into disuse, about 248 of them are currently used in the Passive Station network."},
                    new TrigPointType {Name = "FBM - Fundamental Benchmark",
                        Description ="An underground chamber topped with a short granite pillar. The pillar contains an easily accessible height reference point, but the accurately measured level is underground where it is less likely to be disturbed. There are approximately 207 FBMs across the country and whilst many have fallen into disuse, about 200 have been incorporated into the National GPS Network as Passive Stations."},
                    new TrigPointType {Name = "Surface Block",
                        Description ="Surface blocks are part of the network of Passive Stations. There are 1282 surface blocks in the T:UK database."},
                    new TrigPointType {Name = "Rivet",
                        Description ="Rivets are part of the network of Passive Stations. There are 1232 rivets in the T:UK database."},
                     new TrigPointType {Name = "Berntsen",
                        Description ="Berntsens are part of the network of Passive Stations. There are 103 Berntsens in the T:UK database."},
                    new TrigPointType {Name = "Bolt",
                        Description ="Bolts are part of the network of Passive Stations. There are 4250 bolts in the T:UK database."},
                    new TrigPointType {Name = "Buried Block",
                        Description ="Blocks are part of the network of Passive Stations. There are 2029 blocks in the T:UK database."},
                    new TrigPointType {Name = "Centre",
                        Description ="Centres are part of the network of Passive Stations. There is 0 centre in the T:UK database."},
                    new TrigPointType {Name = "Active Station",
                        Description ="There are 180 active stations in the T:UK database, (including those which are no longer used), which are sited at about 30 locations around the country. These are GPS receivers which constantly log their readings (known as Rinex data) on the Ordnance Survey website. This allows a very high level of positional accuracy to be achieved, without the need to physically occupy one of the Passive Stations."},
                    new TrigPointType {Name = "Flush Bracket",
                        Description = "Flush brackets were fixed to walls at 1 mile intervals between FBMs. They consist of a metal plate with a unique number. There is also a horizontal mark with three vertical marks pointing towards it from below (the same mark as was carved into walls for lower order benchmarks). Flush brackets which are fixed to walls are not included in the database. However, triangulation pillars also boast a flush bracket near their base. Of the 6874 pillars in our database, we only know the FB numbers of 6874 of them! Please help us fill in the gaps."}
               };

                if (!context.TrigPointTypes.Any())
                {
                    foreach (TrigPointType tt in trigPointType)
                    {
                        context.TrigPointTypes.Add(tt);
                    }
                };
                context.SaveChanges();




            }
        }
    }
}