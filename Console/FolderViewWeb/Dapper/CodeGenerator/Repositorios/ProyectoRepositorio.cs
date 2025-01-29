﻿using Dapper;
using FolderView.Dapper.Entidades;
using FolderView.Dapper.Interfaces;
using System.Data;

namespace FolderView.Dapper.Repositorios
{
    public class ProyectoRepositorio : IProyectoRepository
    {
        private readonly DapperContext _context;
        public ProyectoRepositorio(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ProyectoEntidad>> CreateAsync(ProyectoEntidad dto)
        {
            var query = "IA_GEN..[CodeGenerator_Proyecto_Add]";
            var connection = _context.CreateConnection();
            var resultado = await connection.QueryAsync<ProyectoEntidad>(query, new { dto.idTipoProyecto, dto.nombreProyecto }, commandType: CommandType.StoredProcedure);
            return resultado.ToList();
        }

        public async Task<ProyectoEntidad> GetByIdAsync(int id)
        {
            var query = "IA_GEN..[CodeGenerator_Proyecto_GetById]";
            var connection = _context.CreateConnection();
            var resultado = await connection.QuerySingleOrDefaultAsync<ProyectoEntidad>(query, new { id }, commandType: CommandType.StoredProcedure);
            return resultado;
        }

        public async Task<ProyectoEntidad> UpdateAsync(ProyectoEntidad dto)
        {
            var query = "IA_GEN..[CodeGenerator_Proyecto_Update]";
            var connection = _context.CreateConnection();
            var resultado = await connection.QuerySingleOrDefaultAsync<ProyectoEntidad>(query, new { dto.id, dto.idTipoProyecto, dto.nombreProyecto }, commandType: CommandType.StoredProcedure);
            return resultado;
        }

        public async Task<ProyectoEntidad> DeleteAsync(int id)
        {
            var query = "IA_GEN..[CodeGenerator_Proyecto_Delete]";
            var connection = _context.CreateConnection();
            var resultado = await connection.QuerySingleOrDefaultAsync<ProyectoEntidad>(query, new { id }, commandType: CommandType.StoredProcedure);
            return resultado;
        }

        public async Task<List<ProyectoEntidad>> GetAllByIdTipoProyectoAsync(int idTipoProyecto)
        {
            var query = "IA_GEN..[CodeGenerator_Proyecto_GetAllByTipoProyecto]";
            var connection = _context.CreateConnection();
            var resultado = await connection.QueryAsync<ProyectoEntidad>(query, new { idTipoProyecto }, commandType: CommandType.StoredProcedure);
            return resultado.ToList();
        }

       
    }

}
