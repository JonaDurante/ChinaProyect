using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.DataModels.Business;

namespace StudioAdminData.Services
{
    public class ActivityValueService : IActivityValueService
    {
        private readonly StudioAdminDBContext _context;
        public ActivityValueService(StudioAdminDBContext context, ICourseServices courseServices)
        {
            _context = context;
        }

        public List<ActivityValue> GetAllValues() {
            var ActividyAndValue = from activities in _context.ActivityValues
                                   select activities;
            return ActividyAndValue.ToList(); 
        }
        public ActivityValue GetActivityValue(int quantity)
        {
            return _context.ActivityValues.Where(a => a.Quantity == quantity).First();
        }
        public (List<int>, List<decimal>) GetByRoll(Third third) {

            var Quantity = new List<int>();
            var Value = new List<decimal>();
            var ActividyAndValue = GetAllValues();
            Quantity.AddRange(ActividyAndValue.Select(a => a.Quantity));
            if (third.User.Roles == "Profesor")
            {
                Value.AddRange(ActividyAndValue.Select(d => d.ProfessorValue).ToList());
            }else 
            {
                Value.AddRange(ActividyAndValue.Select(d => d.StudenValue).ToList());
            }
            return (Quantity, Value);
        }

        public bool Update(ActivityValue activityValue) {
            var resultado = false;
            var ActividyAndValue = GetActivityValue(activityValue.Quantity);
            try
            {
                if (ActividyAndValue != null)
                {
                    ActividyAndValue.Quantity = activityValue.Quantity;
                    ActividyAndValue.ProfessorValue = activityValue.ProfessorValue;
                    ActividyAndValue.StudenValue = activityValue.StudenValue;
                    resultado = _context.SaveChanges() != 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                //guardar error
            }
            return resultado;
        }

        public bool Insert(ActivityValue activityValue) {
            var resultado = false;
            try
            {
                if (activityValue != null)
                {
                    _context.Add(activityValue);
                    resultado = _context.SaveChanges() !=0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                //guardar error
            }
            return resultado;
        }
    }

}
