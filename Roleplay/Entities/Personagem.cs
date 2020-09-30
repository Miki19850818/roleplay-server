﻿using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Roleplay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Roleplay.Entities
{
    public class Personagem
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Usuario { get; set; } = 0;
        public long SocialClubRegistro { get; set; } = 0;
        public long SocialClubUltimoAcesso { get; set; } = 0;
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public string IPRegistro { get; set; } = string.Empty;
        public long HardwareIdHashRegistro { get; set; } = 0;
        public long HardwareIdExHashRegistro { get; set; } = 0;
        public DateTime DataUltimoAcesso { get; set; } = DateTime.Now;
        public string IPUltimoAcesso { get; set; } = string.Empty;
        public long HardwareIdHashUltimoAcesso { get; set; } = 0;
        public long HardwareIdExHashUltimoAcesso { get; set; } = 0;
        public long Skin { get; set; } = (long)PedModel.FreemodeMale01;
        public float PosX { get; set; } = 128.4853f;
        public float PosY { get; set; } = -1737.086f;
        public float PosZ { get; set; } = 30.11018f;
        public int Vida { get; set; } = 100;
        public int Colete { get; set; } = 0;
        public long Dimensao { get; set; } = 0;
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public bool Online { get; set; } = true;
        public int TempoConectado { get; set; } = 0;
        public int Faccao { get; set; } = 0;
        public int Rank { get; set; } = 0;
        public int Dinheiro { get; set; } = 0;
        public int Celular { get; set; } = 0;
        public int Banco { get; set; } = 3500;
        public string IPL { get; set; } = "[]";
        public int CanalRadio { get; set; } = -1;
        public int CanalRadio2 { get; set; } = 0;
        public int CanalRadio3 { get; set; } = 0;
        public float RotX { get; set; } = 0;
        public float RotY { get; set; } = 0;
        public float RotZ { get; set; } = 149.1595f;
        public DateTime? DataMorte { get; set; } = null;
        public string MotivoMorte { get; set; } = string.Empty;
        public TipoEmprego Emprego { get; set; } = TipoEmprego.Nenhum;
        public string InformacoesPersonalizacao { get; set; } = "[]";
        public string RoupasCivil { get; set; } = string.Empty;
        public string Historia { get; set; } = string.Empty;
        public int UsuarioStaffAvaliador { get; set; } = 0;
        public string MotivoRejeicao { get; set; } = string.Empty;
        public TipoStatusNamechange StatusNamechange { get; set; } = TipoStatusNamechange.Liberado;
        public TipoEtapaPersonalizacao EtapaPersonalizacao { get; set; } = TipoEtapaPersonalizacao.Caracteristicas;
        public DateTime? DataExclusao { get; set; } = null;
        public DateTime? DataTerminoPrisao { get; set; } = null;
        public DateTime? DataValidadeLicencaMotorista { get; set; } = null;
        public DateTime? DataRevogacaoLicencaMotorista { get; set; } = null;
        public int Distintivo { get; set; } = 0;
        public string InformacoesRoupas { get; set; } = "[]";
        public string InformacoesAcessorios { get; set; } = "[]";
        public string InformacoesArmas { get; set; } = "[]";
        public string InformacoesContatos { get; set; } = "[]";
        public DateTime? DataUltimoUsoBarbearia { get; set; } = null;
        public int PecasVeiculares { get; set; } = 0;

        [NotMapped]
        public Personalizacao PersonalizacaoDados { get; set; } = new Personalizacao();

        [NotMapped]
        public int ID { get; set; }

        [NotMapped]
        public Usuario UsuarioBD { get; set; }

        [NotMapped]
        public IPlayer Player { get; set; }

        [NotMapped]
        public DateTime DataUltimaVerificacao { get; set; }

        [NotMapped]
        public Faccao FaccaoBD { get => Global.Faccoes.FirstOrDefault(x => x.Codigo == Faccao); }

        [NotMapped]
        public Rank RankBD { get => Global.Ranks.FirstOrDefault(x => x.Faccao == Faccao && x.Codigo == Rank); }

        [NotMapped]
        public List<Convite> Convites { get; set; } = new List<Convite>();

        [NotMapped]
        public List<Propriedade> Propriedades { get => Global.Propriedades.Where(x => x.Personagem == Codigo).ToList(); }

        [NotMapped]
        public string NomeIC { get => Nome; }

        [NotMapped]
        public List<Contato> Contatos { get; set; } = new List<Contato>();

        [NotMapped]
        public int NumeroLigacao { get; set; } = 0;

        [NotMapped]
        public TipoStatusLigacao StatusLigacao { get; set; } = TipoStatusLigacao.Nenhum;

        [NotMapped]
        public string ExtraLigacao { get; set; } = string.Empty;

        [NotMapped]
        public TagTimer TimerCelular { get; set; }

        [NotMapped]
        public bool EmTrabalho { get; set; } = false;

        [NotMapped]
        public List<string> IPLs { get; set; }

        [NotMapped]
        public bool Algemado { get; set; } = false;

        [NotMapped]
        public int AguardandoTipoServico { get; set; } = 0;

        [NotMapped]
        public bool EmTrabalhoAdministrativo { get; set; } = false;

        [NotMapped]
        public List<Roupa> Roupas { get; set; } = new List<Roupa>();

        [NotMapped]
        public List<Roupa> Acessorios { get; set; } = new List<Roupa>();

        [NotMapped]
        public List<Ferimento> Ferimentos { get; set; } = new List<Ferimento>();

        [NotMapped]
        public TagTimer TimerFerido { get; set; } = null;

        [NotMapped]
        public List<Arma> Armas { get; set; } = new List<Arma>();

        [NotMapped]
        public string AreaName { get; set; }

        [NotMapped]
        public string ZoneName { get; set; }

        [NotMapped]
        public string StringArmas { get; set; }

        [NotMapped]
        public Position PosicaoIC
        {
            get
            {
                if (Player.Dimension == 0)
                    return Player.Position;

                var prop = Global.Propriedades.FirstOrDefault(x => x.Codigo == Player.Dimension);
                return new Position(prop.EntradaPosX, prop.EntradaPosY, prop.EntradaPosZ);
            }
        }

        [NotMapped]
        public int SlotsPersonagens
        {
            get
            {
                return UsuarioBD.VIP switch
                {
                    TipoVIP.Bronze => 3,
                    TipoVIP.Prata => 4,
                    TipoVIP.Ouro => 5,
                    _ => 2,
                };
            }
        }

        [NotMapped]
        public Position? PosicaoSpec { get; set; } = null;

        [NotMapped]
        public int DimensaoSpec { get; set; } = 0;

        [NotMapped]
        public int IDSpec { get; set; } = 0;

        [NotMapped]
        public List<string> IPLsSpec { get; set; } = new List<string>();

        [NotMapped]
        public string CorStaff => UsuarioBD.Staff switch
        {
            TipoStaff.Moderator => "#804000",
            TipoStaff.GameAdministrator => "#40BFFF",
            TipoStaff.LeadAdministrator => "#00AA00",
            TipoStaff.Manager => "#CC4545",
            _ => "#000000",
        };

        public void SetDinheiro()
        {
            if (Player != null)
                Player.SetSyncedMetaData("dinheiro", $"${Dinheiro:N0}");
        }

        public string ObterNomeContato(int numero)
        {
            if (numero == 911)
                return "Central de Emergência";

            if (numero == 5555555)
                return "Downtown Cab Company";

            if (numero == 7777777)
                return "Central de Mecânicos";

            var contato = Contatos.FirstOrDefault(x => x.Celular == numero);
            return contato == null ? $"#{numero}" : $"{contato.Nome} #{numero}";
        }

        public void LimparLigacao(bool isApenasPararTimer = false)
        {
            TimerCelular?.Stop();
            TimerCelular = null;

            if (!isApenasPararTimer)
            {
                NumeroLigacao = 0;
                StatusLigacao = TipoStatusLigacao.Nenhum;
                ExtraLigacao = string.Empty;
            }
        }

        public void SetarIPLs()
        {
            foreach (var ipl in IPLs)
                Player.Emit("Server:RequestIpl", ipl);
        }

        public void LimparIPLs()
        {
            foreach (var ipl in IPLs)
                Player.Emit("Server:RemoveIpl", ipl);

            IPLs.Clear();
        }

        public void PlayAnimation(string dic, string name, int flag)
        {
            Player.Emit("Server:PlayAnim", dic, name, flag);
            Player.SetSyncedMetaData("animation", true);
        }

        public void StopAnimation()
        {
            Player.Emit("Server:StopAnim");
            Player.SetSyncedMetaData("animation", false);
        }

        public void SetClothes(int slot, int drawable, int texture, bool setar = true)
        {
            Roupas.RemoveAll(x => x.Slot == slot);
            Roupas.Add(new Roupa() { Slot = slot, Drawable = drawable, Texture = texture });

            if (setar)
                Player.Emit("Server:SetClothes", slot, drawable, texture);
        }

        public void SetAccessories(int slot, int drawable, int texture, bool setar = true)
        {
            Acessorios.RemoveAll(x => x.Slot == slot);
            Acessorios.Add(new Roupa() { Slot = slot, Drawable = drawable, Texture = texture });

            if (setar)
                Player.Emit("Server:SetAccessories", slot, drawable, texture);
        }

        public void SetPosition(Position position, bool spawn)
        {
            if (spawn)
                Player.Spawn(position);
            else
                Player.Position = position;

            foreach (var x in Global.PersonagensOnline.Where(x => x.IDSpec == ID))
            {
                x.LimparIPLs();
                x.IPLs = IPLs;
                x.SetarIPLs();
                x.Player.Dimension = Player.Dimension;
                x.SetPosition(new Position(position.X, position.Y, position.Z + 5), true);
                x.Player.Emit("SpectatePlayer", Player);
            }
        }

        public void Unspectate()
        {
            LimparIPLs();
            IPLs = IPLsSpec;
            SetarIPLs();
            Player.Dimension = DimensaoSpec;
            Player.SetSyncedMetaData("nametag", NomeIC);
            SetPosition(PosicaoSpec.Value, true);
            PosicaoSpec = null;
            DimensaoSpec = IDSpec = 0;
            IPLsSpec = new List<string>();
            Player.Emit("UnspectatePlayer");
        }

        public class Ferimento
        {
            public DateTime Data { get; set; } = DateTime.Now;
            public ushort Dano { get; set; }
            public uint Arma { get; set; }
            public int CodigoAttacker { get; set; }
            public sbyte BodyPart { get; set; } = -2;
        }

        public class Roupa
        {
            public int Slot { get; set; }
            public int Drawable { get; set; }
            public int Texture { get; set; }
        }

        public class Arma
        {
            public long Codigo { get; set; }
            public int Municao { get; set; } = 0;
            public int Pintura { get; set; } = 0;
            public string Componentes { get; set; } = "[]";
        }

        public class Contato
        {
            public int Celular { get; set; }
            public string Nome { get; set; }
        }

        public class Personalizacao
        {
            /// <summary>
            /// 0 - Mulher
            /// 1 - Homem
            /// </summary>
            public int sex { get; set; } = 1;
            public int faceFather { get; set; } = 0;
            public int faceMother { get; set; } = 0;
            public int skinFather { get; set; } = 0;
            public int skinMother { get; set; } = 0;
            public double faceMix { get; set; } = 0.5;
            public double skinMix { get; set; } = 0.5;
            public List<double> structure { get; set; } = new List<double>();
            public int hair { get; set; } = 4;
            public int hairColor1 { get; set; } = 1;
            public int hairColor2 { get; set; } = 5;
            public HairOverlay hairOverlay { get; set; } = new HairOverlay("multiplayer_overlays", "NG_M_Hair_004");
            public int facialHair { get; set; } = 0;
            public int facialHairColor1 { get; set; } = 0;
            public double facialHairOpacity { get; set; } = 0;
            public int eyebrows { get; set; } = 0;
            public double eyebrowsOpacity { get; set; } = 0;
            public int eyebrowsColor1 { get; set; } = 0;
            public int eyes { get; set; } = 0;
            public List<OpacityOverlay> opacityOverlays { get; set; } = new List<OpacityOverlay>();
            public List<ColorOverlay> colorOverlays { get; set; } = new List<ColorOverlay>();

            public class HairOverlay
            {
                public HairOverlay(string _collection, string _overlay)
                {
                    collection = _collection;
                    overlay = _overlay;
                }

                public string collection { get; set; }
                public string overlay { get; set; }
            }

            public class OpacityOverlay
            {
                public OpacityOverlay(int _id)
                {
                    id = _id;
                }

                public int id { get; set; } = 0;
                public double opacity { get; set; } = 0;
                public double value { get; set; } = 0;
            }

            public class ColorOverlay
            {
                public ColorOverlay(int _id)
                {
                    id = _id;
                }

                public int id { get; set; } = 0;
                public double opacity { get; set; } = 0;
                public int color1 { get; set; } = 0;
                public int color2 { get; set; } = 0;
                public double value { get; set; } = 0;
            }
        }
    }
}