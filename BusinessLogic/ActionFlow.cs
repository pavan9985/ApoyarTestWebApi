using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public class ActionFlow
    {

        public async Task<OuputModel> SampleActionFlow(InputModel inputModel)
        {
            OuputModel outputModel;

            switch (inputModel.actionType)
            {
                case CommonModels.ActionType.AddEmployee:

                    AddEmployee addEmployee = new AddEmployee();
                    outputModel = addEmployee.Add(inputModel);

                    break;
                case CommonModels.ActionType.EditEmployee:

                    EditEmployee editEmployee = new EditEmployee();
                    outputModel = editEmployee.Edit(inputModel);

                    break;
                case CommonModels.ActionType.DeleteEmployee:

                    DeleteEmployee deleteEmployee = new DeleteEmployee();
                    outputModel = deleteEmployee.Delete(inputModel);

                    break;
                case CommonModels.ActionType.GetEmployee:

                    GetEmployeeList getEmployeeList = new GetEmployeeList();
                    outputModel = getEmployeeList.Get(inputModel);

                    break;


                case CommonModels.ActionType.AddDept:

                    AddDepatment addDepatment = new AddDepatment();
                    outputModel = addDepatment.Add(inputModel);

                    break;
                case CommonModels.ActionType.EditDept:

                    EditDepatment editDepatment = new EditDepatment();
                    outputModel = editDepatment.Edit(inputModel);

                    break;
                case CommonModels.ActionType.DeleteDept:

                    DeleteDepatment deleteDepatment = new DeleteDepatment();
                    outputModel = deleteDepatment.Delete(inputModel);

                    break;
                case CommonModels.ActionType.GetDept:

                    GetDepatmentList GetDepatmentList = new GetDepatmentList();
                    outputModel = GetDepatmentList.Get(inputModel);

                    break;
                case CommonModels.ActionType.Login:

                    LoginAction loginAction = new LoginAction();
                    outputModel = loginAction.login(inputModel);

                    break;
                case CommonModels.ActionType.ForgotPassword:

                    LoginGet LoginGet = new LoginGet();
                    outputModel = LoginGet.Getlogin(inputModel);

                    break;





                default:
                    outputModel = new OuputModel()
                    {
                        
                    };
                    break;
            }

            return await Task.FromResult(outputModel);
        }
    }
}
