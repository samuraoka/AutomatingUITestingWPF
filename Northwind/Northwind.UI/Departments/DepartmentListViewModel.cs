using System;
using System.Collections.ObjectModel;
using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Departments
{
    public class DepartmentListViewModel : ViewModel
    {
        //TODO
        public Command AddDepartmentCommand { get; private set; }
        public Command<DepartmentDto> EditDepartmentCommand { get; private set; }
        public Command<DepartmentDto> DeleteDepartmentCommand { get; private set; }
        public ObservableCollection<DepartmentDto> Departments { get; private set; }

        public override string Caption
        {
            get
            {
                return "Departments";
            }
        }

        public DepartmentListViewModel()
        {
            //TODO
            AddDepartmentCommand = new Command(AddDepartment);
            EditDepartmentCommand
                = new Command<DepartmentDto>(x => x != null, EditDepartment);
            DeleteDepartmentCommand
                = new Command<DepartmentDto>(x => x != null, DeleteDepartment);
            //TODO
        }

        public override void RefreshAll()
        {
            //TODO
            base.RefreshAll();
        }

        private void AddDepartment()
        {
            var viewModel = new DepartmentViewModel(new Department());

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                //TODO next
                throw new NotImplementedException();
            }
        }

        private void EditDepartment(DepartmentDto obj)
        {
            //TODO
            throw new NotImplementedException();
        }

        private void DeleteDepartment(DepartmentDto obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
