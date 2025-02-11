﻿using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Roleplay.Entities;
using Roleplay.Models;
using System;
using System.Linq;

namespace Roleplay.Commands.Staff
{
    public class GameAdministrator
    {
        [Command("o", "/o (mensagem)", GreedyArg = true)]
        public void CMD_o(IPlayer player, string mensagem)
        {
            var p = Functions.ObterPersonagem(player);
            if ((int)p?.UsuarioBD?.Staff < (int)TipoStaff.GameAdministrator)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            foreach (var pl in Global.PersonagensOnline)
                Functions.EnviarMensagem(pl.Player, TipoMensagem.Nenhum, $"(( {p.UsuarioBD.Nome}: {mensagem} ))", "#AAC4E5");
        }

        [Command("checar", "/checar (ID ou nome)")]
        public void CMD_checar(IPlayer player, string idNome)
        {
            var p = Functions.ObterPersonagem(player);
            if ((int)p?.UsuarioBD?.Staff < (int)TipoStaff.GameAdministrator)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            var target = Functions.ObterPersonagemPorIdNome(player, idNome);
            if (target == null)
                return;

            Functions.MostrarStats(player, target);
        }

        [Command("ban", "/ban (ID ou nome) (dias) (motivo)", GreedyArg = true)]
        public void CMD_ban(IPlayer player, string idNome, int dias, string motivo)
        {
            var p = Functions.ObterPersonagem(player);
            if ((int)p?.UsuarioBD?.Staff < (int)TipoStaff.GameAdministrator)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            var target = Functions.ObterPersonagemPorIdNome(player, idNome, false);
            if (target == null)
                return;

            if (target.UsuarioBD.Staff >= p.UsuarioBD.Staff)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            using (var context = new DatabaseContext())
            {
                var ban = new Banimento()
                {
                    Data = DateTime.Now,
                    Expiracao = null,
                    Motivo = motivo,
                    Usuario = target.UsuarioBD.Codigo,
                    SocialClub = target.UsuarioBD.SocialClubRegistro,
                    UsuarioStaff = p.UsuarioBD.Codigo,
                    HardwareIdHash = target.HardwareIdHashUltimoAcesso,
                    HardwareIdExHash = target.HardwareIdExHashUltimoAcesso,
                };

                if (dias > 0)
                    ban.Expiracao = DateTime.Now.AddDays(dias);

                context.Banimentos.Add(ban);

                context.Punicoes.Add(new Punicao()
                {
                    Data = DateTime.Now,
                    Duracao = dias,
                    Motivo = motivo,
                    Personagem = target.Codigo,
                    Tipo = TipoPunicao.Ban,
                    UsuarioStaff = p.UsuarioBD.Codigo,
                });
                context.SaveChanges();
            }

            Functions.SalvarPersonagem(target, false);
            var strBan = dias == 0 ? "permanentemente" : $"por {dias} dia{(dias > 1 ? "s" : string.Empty)}";
            Functions.EnviarMensagemStaff($"{p.UsuarioBD.Nome} baniu {target.UsuarioBD.Nome} ({target.Nome}) {strBan}. Motivo: {motivo}", false);
            target.Player.Kick($"{p.UsuarioBD.Nome} baniu você {strBan}. Motivo: {motivo}");
        }

        [Command("banoff", "/banoff (personagem) (dias) (motivo)", GreedyArg = true)]
        public void CMD_banoff(IPlayer player, int personagem, int dias, string motivo)
        {
            var p = Functions.ObterPersonagem(player);
            if ((int)p?.UsuarioBD?.Staff < (int)TipoStaff.GameAdministrator)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            using var context = new DatabaseContext();
            var per = context.Personagens.FirstOrDefault(x => x.Codigo == personagem);
            if (per == null)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Personagem {personagem} não existe.");
                return;
            }

            var user = context.Usuarios.FirstOrDefault(x => x.Codigo == per.Usuario);

            if (user.Staff >= p.UsuarioBD.Staff)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            var ban = new Banimento()
            {
                Data = DateTime.Now,
                Expiracao = null,
                Motivo = motivo,
                Usuario = user.Codigo,
                SocialClub = user.SocialClubRegistro,
                UsuarioStaff = p.UsuarioBD.Codigo,
            };

            if (dias > 0)
                ban.Expiracao = DateTime.Now.AddDays(dias);

            context.Banimentos.Add(ban);

            context.Punicoes.Add(new Punicao()
            {
                Data = DateTime.Now,
                Duracao = dias,
                Motivo = motivo,
                Personagem = per.Codigo,
                Tipo = TipoPunicao.Ban,
                UsuarioStaff = p.UsuarioBD.Codigo,
            });
            context.SaveChanges();

            var strBan = dias == 0 ? "permanentemente" : $"por {dias} dia{(dias > 1 ? "s" : string.Empty)}";
            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você baniu {user.Nome} ({per.Nome}) {strBan}. Motivo: {motivo}");
        }

        [Command("unban", "/unban (usuario)")]
        public void CMD_unban(IPlayer player, string usuario)
        {
            var p = Functions.ObterPersonagem(player);
            if ((int)p?.UsuarioBD?.Staff < (int)TipoStaff.GameAdministrator)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            using (var context = new DatabaseContext())
            {
                var user = context.Usuarios.FirstOrDefault(x => x.Nome.ToLower() == usuario.ToLower());
                if (user == null)
                {
                    Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Usuário {usuario} não existe.");
                    return;
                }

                var ban = context.Banimentos.FirstOrDefault(x => x.Usuario == user.Codigo);
                if (ban == null)
                {
                    Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Usuário {usuario} não está banido.");
                    return;
                }

                context.Banimentos.Remove(ban);
                context.SaveChanges();
            }

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você desbaniu {usuario}.");
            Functions.GravarLog(TipoLog.Staff, $"/unban {usuario}", p, null);
        }

        [Command("checaroff", "/checaroff (código ou nome do personagem)", GreedyArg = true)]
        public void CMD_checaroff(IPlayer player, string idNome)
        {
            var p = Functions.ObterPersonagem(player);
            if ((int)p?.UsuarioBD?.Staff < (int)TipoStaff.GameAdministrator)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            int.TryParse(idNome, out int codigo);
            using var context = new DatabaseContext();
            var personagem = context.Personagens.FirstOrDefault(x => x.Codigo == codigo || x.Nome.ToLower() == idNome.ToLower());
            if (personagem == null)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Nenhum personagem encontrado através da pesquisa: {idNome}.");
                return;
            }

            personagem.UsuarioBD = context.Usuarios.FirstOrDefault(x => x.Codigo == personagem.Usuario);
            Functions.MostrarStats(player, personagem);
        }

        [Command("pos", "/pos (x) (y) (z)")]
        public void CMD_pos(IPlayer player, float x, float y, float z)
        {
            var p = Functions.ObterPersonagem(player);
            if ((int)p?.UsuarioBD?.Staff < (int)TipoStaff.GameAdministrator)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            p.SetPosition(new Position(x, y, z), false);
            Functions.GravarLog(TipoLog.Staff, $"/pos {x} {y} {z}", p, null);
        }
    }
}