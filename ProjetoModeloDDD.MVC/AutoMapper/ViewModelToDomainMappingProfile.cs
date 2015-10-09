using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    /// <summary>
    /// Classe de configuração do AutoMapper
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Aqui esta reescrevendo o nome do Profile
        /// </summary>
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        /// <summary>
        /// Confiração do AutoMapper de ViewModel para Dominio
        /// </summary>
        protected override void Configure()
        {
            // Quando vi Cliente (Entity) vai para ClienteViewModel
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            // Quando vi Produto (Entity) vai para ProdutoViewModel
            Mapper.CreateMap<Produto, ProdutoViewModel>();
        }
    }
}