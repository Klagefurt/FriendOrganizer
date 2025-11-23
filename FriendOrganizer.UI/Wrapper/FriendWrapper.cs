using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
        }

        public int Id => Model.Id;

        public string FirstName
        {
            get
            {
                //return Model.FirstName; 
                return GetValue<string>();
            }

            set => SetValue(value);
        }



        //private void ValidateProperty(string propertyName)
        //{
        //    ClearErrors(propertyName);
        //    
        //}

        public string LastName
        {
            get 
            {
                //return Model.LastName;
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }

        public string Email
        { 
            get 
            {
                // return Model.Email;
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not valid friends";
                    }
                    break;
            }
        }
        }
}
