using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    /// <summary>
    /// Classe de configuração do AutoMapper
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Aqui esta reescrevendo o nome do Profile
        /// </summary>
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        /// <summary>
        /// Confiração do AutoMapper de Domínio para ViewModel
        /// </summary>
        protected override void Configure()
        {
            // Quando vi ClienteViewModel vai para Cliente (Entity)
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            // Quando vi ProdutoViewModel vai para Produto (Entity)
            Mapper.CreateMap<ProdutoViewModel, Produto>();
        }
    }
}