using System.Threading.Tasks;
using WrcaySalesInventorySystem.Classs.Interface;

namespace WrcaySalesInventorySystem.ViewModel
{
    public class ViewModelCategory //: ViewModelBase, IDataCommand
    {
        //private Category _category;
        //private ApplicationDatabaseContext _databaseContext;

        //public ViewModelCategory(Category category, ApplicationDatabaseContext databaseContext)
        //{
        //    _category = category;
        //    _databaseContext =  databaseContext;
        //}

        //public string? CategoryName {
        //    get => _category.CategoryName;
        //    set
        //    {
        //        _category.CategoryName = value;
        //        Changed("CategoryName");
        //    }
        //}

        //public string? CategoryDescription
        //{
        //    get => _category.CategoryDescription;
        //    set
        //    {
        //        _category.CategoryDescription = value;
        //        Changed("CategoryDescription");
        //    }
        //}

        //public int CategoryID
        //{
        //    get => _category.CategoryId;
        //    set
        //    {
        //        _category.CategoryId = value;
        //        Changed("CategoryID");
        //    }
        //}

        //public async Task<bool> Add()
        //{
        //    await _databaseContext.Categories.AddAsync(_category);
        //    int res = await _databaseContext.SaveChangesAsync();
        //    return res > 0;
        //}

        //public async Task<bool> Delete()
        //{
        //    _databaseContext.Categories.Remove(_category);
        //    int res = await _databaseContext.SaveChangesAsync();
        //    return res > 0;
        //}

        //public bool Exists()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Task<bool> IsValid()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public async Task<bool> Update()
        //{
        //    _databaseContext.Categories.Update(_category);
        //    int res = await _databaseContext.SaveChangesAsync();
        //    return res > 0;
        //}
    }
}
