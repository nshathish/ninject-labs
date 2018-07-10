using System.Windows.Forms;

namespace Northwind.WindowsApp
{
  using System;
  using System.Linq;
  using Core;

  public partial class Form1 : Form
  {
    private readonly ICustomerRepository _repository;

    public Form1(ICustomerRepository repository)
    {
      _repository = repository;
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      LoadCustomers();
    }

    private void LoadCustomers()
    {
      dataGridView1.DataSource = _repository.GetAll().ToList();
    }
  }
}
