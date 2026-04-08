using CrudCafeteria.DTOs;
using CrudCafeteria.Models.Enums;

public interface ISolicitacaoService
{
    Task<List<ResponseSolicitacaoDto>> GetAll(string? status , string? prioridade);
    Task<ResponseSolicitacaoDto?> GetById(int id);
    Task<ResponseSolicitacaoDto> Create(CreateSolicitacaoDto dto);
    Task<bool> Update(int id, UpdateSolicitacaoDto dto);
    Task<bool> Delete(int id);
}