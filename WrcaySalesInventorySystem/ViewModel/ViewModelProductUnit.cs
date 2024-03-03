using System.Data.SqlClient;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelProductUnit : ViewModelBase, IDataCommand
    {
        private int _id;
        private string? _name;
        private string? _dateAdded;
        private string? _dateUpdated;
        private string? _createdUser;
        private string? _updatedUser;
        private SqlConnection? _sqlConnection;
        private SqlCommand? sqlCommand;


        public string? CreatedUser
        {
            get => _createdUser;
            set
            {
                _createdUser = value;
                Changed("CreatedUser");
            }
        }

        public string? UpdatedUser
        {
            get => _updatedUser;
            set
            {
                _updatedUser = value;
                Changed("updatedUser");
            }
        }

        public int UnitID
        {
            get => _id;
            set
            {
                _id = value;
                Changed("UnitID");
            }
        }

        public string? UnitName
        {
            get => _name;
            set
            {
                _name = value;
                Changed("UnitName");
            }
        }

        public string? DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                Changed("DateAdded");
            }
        }

        public string? DateUpdated
        {
            get => _dateUpdated;
            set
            {
                _dateUpdated = value;
                Changed("DateUpdated");
            }
        }

        public bool Add()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists()
        {
            throw new System.NotImplementedException();
        }

        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }

        public bool Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
