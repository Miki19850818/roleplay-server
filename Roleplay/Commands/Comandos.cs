﻿using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using Newtonsoft.Json;
using Roleplay.Entities;
using Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.Commands
{
    public class Comandos
    {
        [Command("ajuda")]
        public void CMD_ajuda(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            if (p == null)
                return;

            var listaComandos = new List<Comando>()
            {
                new Comando("Teclas", "F2", "Jogadores online"),
                new Comando("Teclas", "F7", "Habilita/desabilita a HUD"),
                new Comando("Teclas", "B", "Aponta/para de apontar o dedo estando fora de um veículo"),
                new Comando("Geral", "/stats", "Mostra as informações do seu personagem"),
                new Comando("Geral", "/id", "Procura o ID de um personagem"),
                new Comando("Geral", "/aceitar /ac", "Aceita um convite"),
                new Comando("Geral", "/recusar /rc", "Recusa um convite"),
                new Comando("Geral", "/pagar", "Transfere dinheiro da carteira para um personagem"),
                new Comando("Geral", "/revistar", "Solicita uma revista em um personagem"),
                new Comando("Geral", "/multas", "Visualiza suas multas pendentes"),
                new Comando("Geral", "/comprar", "Compra um veículo, propriedade ou item"),
                new Comando("Geral", "/skin", "Compra roupas"),
                new Comando("Geral", "/emprego", "Pega um emprego"),
                new Comando("Geral", "/staff", "Lista os membros da staff que estão online"),
                new Comando("Geral", "/sos", "Envia solicitação de ajuda aos administradores em serviço"),
                new Comando("Geral", "/ferimentos", "Visualiza os ferimentos de um personagem"),
                new Comando("Geral", "/aceitarhospital", "Aceita o tratamento médico após estar ferido e é levado ao hospital"),
                new Comando("Geral", "/aceitarck", "Aceita o CK no personagem"),
                new Comando("Geral", "/trancar", "Traca/destranca propriedades e veículos"),
                new Comando("Geral", "/entregararma", "Entrega uma arma para um personagem"),
                new Comando("Geral", "/timestamp", "Ativa/desativa timestamp do chat"),
                new Comando("Geral", "/barbearia", "Realiza alterações no cabelo em uma barbearia"),
                new Comando("Geral", "/maquiagem", "Realiza alterações na maquiagem em uma barbearia"),
                new Comando("Geral", "/roupas", "Realiza alterações nas roupas em uma loja de roupas"),
                new Comando("Geral", "/mostrarid", "Mostra a identidade para um personagem"),
                new Comando("Geral", "/dmv", "Compra/renova a licença de motorista"),
                new Comando("Geral", "/mostrarlicenca", "Mostra a licença de motorista para um personagem"),
                new Comando("Geral", "/tog", "Ativa/desativa opções (pm chatstaff chatfaccao anuncio)"),
                new Comando("Geral", "/horas", "Exibe o horário"),
                new Comando("Geral", "/telapreta", "Exibe um fundo preto na tela"),
                new Comando("Geral", "/telacinza", "Exibe um fundo cinza na tela"),
                new Comando("Geral", "/telaverde", "Exibe um fundo verde na tela"),
                new Comando("Geral", "/telalaranja", "Exibe um fundo laranja na tela"),
                new Comando("Geral", "/limparchat", "Limpa o seu chat"),
                new Comando("Geral", "/dl", "Ativa/desativa informações dos veículos"),
                new Comando("Geral", "/mecurar", "Trata os ferimentos em um hospital"),
                new Comando("Geral", "/mascara", "Coloca/retira uma máscara"),
                new Comando("Geral", "/depositarpoupanca", "Aplica $50.000 na poupança"),
                new Comando("Geral", "/sacarpoupanca", "Saca todo o dinheiro da poupança"),
                new Comando("Geral", "/save", "Exibe sua posição e rotação ou do seu veículo no console"),
                new Comando("Propriedades", "/entrar", "Entra de uma propriedade"),
                new Comando("Propriedades", "/sair", "Sai de uma propriedade"),
                new Comando("Propriedades", "/pvender", "Vende uma propriedade para um personagem"),
                new Comando("Propriedades", "/liberarprop", "Libera uma propriedade de um personagem inativo"),
                new Comando("Propriedades", "/abandonar", "Abandona uma propriedade"),
                new Comando("Propriedades", "/guardaroupas", "Altera sua roupa"),
                new Comando("Chat IC", "/me", "Interpretação de ações de um personagem"),
                new Comando("Chat IC", "/do", "Interpretação do ambiente"),
                new Comando("Chat IC", "/g", "Grita"),
                new Comando("Chat IC", "/baixo", "Fala baixo"),
                new Comando("Chat IC", "/s", "Sussura"),
                new Comando("Chat IC", "/ame", "Interpretação de ações de um personagem"),
                new Comando("Chat IC", "/ado", "Interpretação do ambiente"),
                new Comando("Chat OOC", "/b", "Chat OOC local"),
                new Comando("Chat OOC", "/pm", "Envia uma mensagem privada"),
                new Comando("Celular", "/sms", "Envia um SMS"),
                new Comando("Celular", "/desligar /des", "Desliga a ligação"),
                new Comando("Celular", "/ligar", "Liga para um número"),
                new Comando("Celular", "/atender /at", "Atende uma ligação"),
                new Comando("Celular", " /celular /cel", "Abre o celular"),
                new Comando("Celular", "/gps", "Traça rota para uma propriedade"),
                new Comando("Celular", "/localizacao", "Envia sua localização atual para um número"),
                new Comando("Celular", "/an", "Faz um anúncio"),
                new Comando("Veículos", "/motor", "Liga/desliga o motor de um veículo"),
                new Comando("Veículos", "/vcomprarvaga", "Compra uma vaga para estacionar um veículo"),
                new Comando("Veículos", "/vestacionar", "Estaciona um veículo"),
                new Comando("Veículos", "/vlista", "Mostra seus veículos"),
                new Comando("Veículos", "/vvenderpara", "Vende um veículo para outro personagem"),
                new Comando("Veículos", "/vliberar", "Libera um veículo apreendido"),
                new Comando("Veículos", "/portamalas", "Abre/fecha o porta-malas de um veículo"),
                new Comando("Veículos", "/capo", "Abre/fecha o capô de um veículo"),
                new Comando("Veículos", "/porta", "Abre/fecha a porta de um veículo"),
                new Comando("Veículos", "/abastecer", "Abastece um veículo"),
                new Comando("Veículos", "/mudarplaca", "Altera a placa de um veículo"),
                new Comando("Veículos", "/vvender", "Vende um veículo no ferro velho"),
                new Comando("Veículos", "/valugar", "Aluga um veículo"),
                new Comando("Banco", "/depositar", "Deposita dinheiro no banco"),
                new Comando("Banco", "/sacar", "Saca dinheiro do banco"),
                new Comando("Banco", "/transferir", "Transfere dinheiro para outro personagem"),
                new Comando("Animações", "/stopanim /sa","Para as animações"),
                new Comando("Animações", "/crossarms", "Cruza os braços"),
                new Comando("Animações", "/handsup /hs", "Levanta as mãos"),
                new Comando("Animações", "/hsv", "Levanta as mãos"),
                new Comando("Animações", "/smoke", "Fuma"),
                new Comando("Animações", "/lean", "Encosta"),
                new Comando("Animações", "/police", "Faz gestos policiais"),
                new Comando("Animações", "/incar", "Faz animações dentro de um veículo"),
                new Comando("Animações", "/pushups", "Faz flexões"),
                new Comando("Animações", "/situps", "Faz abdominais"),
                new Comando("Animações", "/blunt", "Fuma"),
                new Comando("Animações", "/afishing", "Pesca"),
                new Comando("Animações", "/acop", "Segura o cinto"),
                new Comando("Animações", "/idle", "Fica ocioso"),
                new Comando("Animações", "/barra", "Faz barras"),
                new Comando("Animações", "/revistarc", "Revista ajoelhado"),
                new Comando("Animações", "/ajoelhar", "Ajoelha"),
                new Comando("Animações", "/drink", "Segura o copo"),
                new Comando("Animações", "/morto", "Cai no chão"),
                new Comando("Animações", "/gsign", "Sinais com as mãos"),
                new Comando("Animações", "/hurry", "Chama"),
                new Comando("Animações", "/cair", "Cai"),
                new Comando("Animações", "/wsup", "Cumprimenta"),
                new Comando("Animações", "/render", "Rende"),
                new Comando("Animações", "/mirar", "Mira"),
                new Comando("Animações", "/sentar", "Senta"),
                new Comando("Animações", "/dormir", "Dorme"),
                new Comando("Animações", "/pichar", "Picha"),
                new Comando("Animações", "/sexo", "Safadeza"),
                new Comando("Animações", "/jogado", "Fica jogado no chão"),
                new Comando("Animações", "/reparando", "Apoia em um capô"),
                new Comando("Animações", "/luto", "Segura os pulsos"),
                new Comando("Animações", "/bar", "Escora em um balcão"),
                new Comando("Animações", "/necessidades", "Faz o número 2"),
                new Comando("Animações", "/meth", "Cheira cocaína"),
                new Comando("Animações", "/mijar", "Mija"),
                new Comando("Animações", "/dancar", "Dança"),
                new Comando("Rádio", "/canal", "Troca os canais de rádio"),
                new Comando("Rádio", "/r", "Fala no canal de rádio principal"),
                new Comando("Rádio", "/r2", "Fala no canal de rádio secundário"),
                new Comando("Rádio", "/r3", "Fala no canal de rádio terciário"),
            };

            if (p.Emprego > 0)
            {
                listaComandos.AddRange(new List<Comando>()
                {
                    new Comando("Emprego", "/sairemprego", "Sai do emprego"),
                    new Comando("Emprego", "/duty /trabalho", "Entra/sai de serviço"),
                });

                if (p.Emprego == TipoEmprego.Taxista || p.Emprego == TipoEmprego.Mecanico)
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Emprego", "/chamadas", "Exibe as chamadas aguardando resposta"),
                        new Comando("Emprego", "/atcha", "Atende uma chamada"),
                    });

                if (p.Emprego == TipoEmprego.Mecanico)
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Emprego", "/pintar", "Pinta um veículo"),
                        new Comando("Emprego", "/reparar", "Conserta um veículo"),
                    });

                if (p.Emprego == TipoEmprego.Lixeiro)
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Emprego", "/pegarlixo", "Pega um saco de lixo em um ponto de coleta"),
                        new Comando("Emprego", "/colocarlixo", "Coloca um saco de lixo em um caminhão de lixo"),
                    });
            }

            if (p.Faccao > 0)
            {
                listaComandos.AddRange(new List<Comando>()
                {
                    new Comando("Facção", "/f", "Chat OOC da facção"),
                    new Comando("Facção", "/membros", "Mostra os membros da facção"),
                    new Comando("Facção", "/sairfaccao", "Sai da facção"),
                    new Comando("Facção", "/armario", "Usa o armário da facção"),
                });

                if (p.FaccaoBD.Governamental)
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Facção", "/fspawn", "Spawna veículos da facção"),
                        new Comando("Facção", "/e", "Ativa/desativa extras de veículos da facção"),
                        new Comando("Facção", "/mostrardistintivo", "Mostra seu distintivo para um personagem"),
                        new Comando("Facção", "/freparar", "Conserta veículos da facção"),
                        new Comando("Facção", "/duty /trabalho", "Entra/sai de trabalho"),
                        new Comando("Facção", "/mdc", "Abre o MDC"),
                    });

                if (p.FaccaoBD.Tipo == TipoFaccao.Policial)
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Teclas", "Z", "Desliga/liga som da sirene de um veículo"),
                        new Comando("Facção", "/m", "Fala no megafone"),
                        new Comando("Facção", "/prender", "Prende um personagem"),
                        new Comando("Facção", "/algemar", "Algema/desalgema um personagem"),
                        new Comando("Facção", "/apreender", "Apreende um veículo"),
                        new Comando("Facção", "/uniforme", "Coloca/retira o uniforme de serviço"),
                        new Comando("Facção", "/tac /t", "Entra/sai do canal de voz TAC"),
                        new Comando("Facção", "/confiscar", "Confisca as armas de um personagem"),
                        new Comando("Facção", "/colocar", "Coloca um personagem algemado no banco traseiro de um veículo"),
                    });
                else if (p.FaccaoBD.Tipo == TipoFaccao.Medica)
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Teclas", "Z", "Desliga/liga som da sirene de um veículo"),
                        new Comando("Facção", "/m", "Fala no megafone"),
                        new Comando("Facção", "/curar", "Cura um personagem ferido"),
                        new Comando("Facção", "/uniforme", "Coloca/retira o uniforme de serviço"),
                    });

                if (p.Rank >= p.FaccaoBD.RankGestor)
                {
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Facção Gestor", "/blockf", "Bloqueia/desbloqueia o chat OOC da facção"),
                        new Comando("Facção Gestor", "/convidar", "Convida um personagem para a facção"),
                        new Comando("Facção Gestor", "/rank", "Altera o rank de um personagem na facção"),
                        new Comando("Facção Gestor", "/expulsar", "Expulsa um personagem da facção"),
                    });

                    if (p.FaccaoBD.Governamental)
                        listaComandos.AddRange(new List<Comando>()
                        {
                            new Comando("Facção Gestor", "/gov", "Envia um anúncio governamental da facção"),
                            new Comando("Facção Gestor", "/distintivo", "Atribui um distintivo para um personagem"),
                        });
                }

                if (p.Rank >= p.FaccaoBD.RankLider)
                    listaComandos.AddRange(new List<Comando>()
                    {
                        new Comando("Facção Líder", "/crank", "Cria um rank na facção"),
                        new Comando("Facção Líder", "/eranknome", "Edita o nome de um rank da facção"),
                        new Comando("Facção Líder", "/rrank", "Remove um rank da facção"),
                        new Comando("Facção Líder", "/ranks", "Mostra os ranks da facção"),
                        new Comando("Facção Líder", "/earmirank", "Edita o rank de um item em um armário da facção"),
                    });
            }

            if ((int)p.UsuarioBD.Staff >= (int)TipoStaff.Moderator)
                listaComandos.AddRange(new List<Comando>()
                {
                    new Comando("Moderator", "/ir", "Vai a um personagem"),
                    new Comando("Moderator", "/trazer", "Traz um personagem"),
                    new Comando("Moderator", "/tp", "Teleporta um personagem para outro"),
                    new Comando("Moderator", "/vw", "Altera o VW de um personagem"),
                    new Comando("Moderator", "/a", "Chat administrativo"),
                    new Comando("Moderator", "/kick", "Expulsa um personagem"),
                    new Comando("Moderator", "/irveh", "Vai a um veículo"),
                    new Comando("Moderator", "/trazerveh", "Traz um veículo"),
                    new Comando("Moderator", "/aduty /atrabalho", "Entra/sai de serviço administrativo"),
                    new Comando("Moderator", "/listasos", "Lista os SOSs pendentes"),
                    new Comando("Moderator", "/aj", "Aceita um SOS"),
                    new Comando("Moderator", "/rj", "Rejeita um SOS"),
                    new Comando("Moderator", "/spec", "Observa um personagem"),
                    new Comando("Moderator", "/specoff", "Para de observar um personagem"),
                    new Comando("Moderator", "/aferimentos", "Visualiza os ferimentos de um personagem"),
                    new Comando("Moderator", "/respawnarveiculo", "Estaciona um veículo de aluguel de empregos"),
                    new Comando("Moderator", "/reviver", "Cura um personagem ferido"),
                });

            if ((int)p.UsuarioBD.Staff >= (int)TipoStaff.GameAdministrator)
                listaComandos.AddRange(new List<Comando>()
                {
                    new Comando("Game Administrator", "/o", "Chat OOC Global"),
                    new Comando("Game Administrator", "/checar", "Checa as informações de um personagem online"),
                    new Comando("Game Administrator", "/checaroff", "Checa as informações de um personagem offline"),
                    new Comando("Game Administrator", "/ban", "Bane um usuário"),
                    new Comando("Game Administrator", "/unban", "Desbane um usuário"),
                    new Comando("Game Administrator", "/banoff", "Bane um usuário que está offline"),
                    new Comando("Game Administrator", "/pos", "Vai até a posição"),
                });

            if ((int)p.UsuarioBD.Staff >= (int)TipoStaff.LeadAdministrator)
                listaComandos.AddRange(new List<Comando>()
                {
                    new Comando("Lead Administrator", "/ck", "Aplica CK em um personagem"),
                    new Comando("Lead Administrator", "/tempo", "Altera o tempo"),
                    new Comando("Lead Administrator", "/bloquearnc", "Bloqueia a possibilidade de troca de nome de um personagem"),
                    new Comando("Lead Administrator", "/unck", "Remove CK de um personagem"),
                    new Comando("Lead Administrator", "/limparchatgeral", "Limpa o chat de todos os personagens"),
                    new Comando("Lead Administrator", "/areparar", "Conserta um veículo"),
                });

            if ((int)p.UsuarioBD.Staff >= (int)TipoStaff.Manager)
                listaComandos.AddRange(new List<Comando>()
                {
                    new Comando("Manager", "/gmx", "Salva todas as informações do servidor para reiniciá-lo"),
                    new Comando("Manager", "/proximo /prox", "Lista os itens que estão próximos"),
                    new Comando("Manager", "/cblip", "Cria um blip"),
                    new Comando("Manager", "/rblip", "Remove um blip"),
                    new Comando("Manager", "/setstaff", "Altera o nível de staff de um usuário"),
                    new Comando("Manager", "/cfac", "Cria uma facção"),
                    new Comando("Manager", "/efacnome", "Edita o nome da facção"),
                    new Comando("Manager", "/efactipo", "Edita o tipo da facção"),
                    new Comando("Manager", "/efaccor", "Edita a cor da facção"),
                    new Comando("Manager", "/efacrankgestor", "Edita o rank gestor da facção"),
                    new Comando("Manager", "/efacranklider", "Edita o rank líder da facção"),
                    new Comando("Manager", "/rfac", "Remove uma facção"),
                    new Comando("Manager", "/faccoes", "Mostra as facções"),
                    new Comando("Manager", "/crank", "Cria um rank na facção"),
                    new Comando("Manager", "/eranknome", "Edita o nome de um rank da facção"),
                    new Comando("Manager", "/rrank", "Remove um rank da facção"),
                    new Comando("Manager", "/ranks", "Mostra os ranks da facção"),
                    new Comando("Manager", "/lider", "Atribui o personagem como líder de uma facção"),
                    new Comando("Manager", "/cprop", "Cria uma propriedade"),
                    new Comando("Manager", "/rprop", "Remove uma propriedade"),
                    new Comando("Manager", "/epropvalor", "Altera o valor de uma propriedade"),
                    new Comando("Manager", "/epropint", "Altera o interior de uma propriedade"),
                    new Comando("Manager", "/eproppos", "Altera a posição de entrada de uma propriedade"),
                    new Comando("Manager", "/irblip", "Vai até um blip"),
                    new Comando("Manager", "/irprop", "Vai até uma propriedade"),
                    new Comando("Manager", "/cpreco", "Cria/edita um preço"),
                    new Comando("Manager", "/rpreco", "Remove um preço"),
                    new Comando("Manager", "/cponto", "Cria um ponto"),
                    new Comando("Manager", "/rponto", "Remove um ponto"),
                    new Comando("Manager", "/irponto", "Vai até um ponto"),
                    new Comando("Manager", "/eranksalario", "Altera o salário de um rank"),
                    new Comando("Manager", "/carm", "Cria um armário"),
                    new Comando("Manager", "/earmpos", "Altera a posição de um armário"),
                    new Comando("Manager", "/earmfac", "Altera a facção de um armário"),
                    new Comando("Manager", "/rarm", "Remove um armário"),
                    new Comando("Manager", "/carmi", "Adiciona uma arma em um armário"),
                    new Comando("Manager", "/rarmi", "Remove uma arma de um armário"),
                    new Comando("Manager", "/earmimun", "Altera a munição de uma arma no armário"),
                    new Comando("Manager", "/earmirank", "Altera o rank de uma arma no armário"),
                    new Comando("Manager", "/earmiest", "Altera o estoque de uma arma no armário"),
                    new Comando("Manager", "/irarm", "Vai até um armário"),
                    new Comando("Manager", "/eblipinativo", "Ativa/desativa um blip"),
                    new Comando("Manager", "/cveh", "Cria um veículo para uma facção"),
                    new Comando("Manager", "/cvehemprego", "Cria um veículo para um emprego"),
                    new Comando("Manager", "/rveh", "Remove um veículo de uma facção/emprego"),
                    new Comando("Manager", "/evehcor", "Edita as cores de um veículo"),
                    new Comando("Manager", "/evehlivery", "Edita a livery de um veículo"),
                    new Comando("Manager", "/earmipintura", "Edita a pintura de uma arma do armário"),
                    new Comando("Manager", "/carmicomp", "Adiciona componentes em um arma de um armário"),
                    new Comando("Manager", "/rarmicomp", "Remove componentes em um arma de um armário"),
                    new Comando("Manager", "/ccomp", "Adiciona componentes em um armário"),
                    new Comando("Manager", "/rcomp", "Remove componentes de um armário"),
                    new Comando("Manager", "/ncforum", "Remove o namechange do fórum de um usuário"),
                    new Comando("Manager", "/eponto", "Edita um ponto"),
                    new Comando("Manager", "/jetpack", "Cria um jetpack"),
                    new Comando("Manager", "/param", "Edita um parâmetro do servidor"),
                    new Comando("Manager", "/blackout", "Ativa/desativa blackout"),
                    new Comando("Manager", "/dinheiro", "Adiciona dinheiro para um personagem"),
                    new Comando("Manager", "/contentcreator", "Adiciona/remove um usuário como criador de conteúdo"),
                });

            if (p.Usuario == 1)
                listaComandos.AddRange(new List<Comando>()
                {
                    new Comando("TR3V1Z4", "/vip", "Adiciona VIP para um usuário"),
                });

            var html = $@"
            <input id='pesquisa' type='text' autofocus class='form-control' placeholder='Pesquise os comandos...' /><br/>
            <div class='table-responsive' style='max-height:50vh;overflow-y:auto;overflow-x:hidden;'>
                <table class='table table-bordered table-striped'>
                <thead>
                    <tr class='bg-dark'>
                        <th>Categoria</th>
                        <th>Comando</th>
                        <th>Descrição</th>
                    </tr>
                </thead>
                <tbody>";

            listaComandos = listaComandos.OrderBy(x => x.Categoria).ThenBy(x => x.Nome).ToList();
            foreach (var x in listaComandos)
                html += $@"<tr class='pesquisaitem'><td>{x.Categoria}</td><td>{x.Nome}</td><td>{x.Descricao}</td></tr>";

            html += $@"
                </tbody>
            </table>
            </div>";

            player.Emit("Server:BaseHTML", Functions.GerarBaseHTML($"{Global.NomeServidor} • Lista de Comandos", html));
        }

        [Command("stats")]
        public void CMD_stats(IPlayer player) => Functions.MostrarStats(player, Functions.ObterPersonagem(player));

        [Command("id", "/id (ID ou nome)", GreedyArg = true)]
        public void CMD_id(IPlayer player, string idNome)
        {
            int.TryParse(idNome, out int id);
            var personagens = Global.PersonagensOnline.Where(x => x.ID > 0 && (x.ID == id || x.NomeIC.ToLower().Contains(idNome.ToLower()))).OrderBy(x => x.ID).ToList();
            if (personagens.Count == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Nenhum jogador foi encontrado com a pesquisa: {idNome}.");
                return;
            }

            Functions.EnviarMensagem(player, TipoMensagem.Titulo, $"Jogadores encontrados com a pesquisa: {idNome}.");
            foreach (var pl in personagens)
                Functions.EnviarMensagem(player, TipoMensagem.Nenhum, $"{pl.NomeIC} [{pl.ID}]");
        }

        [Command("aceitar", "/aceitar (tipo)", Alias = "ac")]
        public void CMD_aceitar(IPlayer player, int tipo)
        {
            var p = Functions.ObterPersonagem(player);

            if (!Enum.IsDefined(typeof(TipoConvite), tipo))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Tipo inválido.");
                return;
            }

            var convite = p.Convites.FirstOrDefault(x => x.Tipo == (TipoConvite)tipo);
            if (convite == null)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Você não possui nenhum convite do tipo {tipo}.");
                return;
            }

            var target = Global.PersonagensOnline.FirstOrDefault(x => x.Codigo == convite.Personagem);

            switch ((TipoConvite)tipo)
            {
                case TipoConvite.Faccao:
                    int.TryParse(convite.Valor[0], out int faccao);
                    int.TryParse(convite.Valor[1], out int rank);
                    p.Faccao = faccao;
                    p.Rank = rank;

                    if (p.FaccaoBD?.Tipo != TipoFaccao.Criminosa)
                    {
                        p.Emprego = TipoEmprego.Nenhum;
                        p.EmTrabalho = false;
                    }

                    Functions.EnviarMensagemFaccao(p, $"{p.Nome} entrou na facção.");
                    break;
                case TipoConvite.VendaPropriedade:
                    if (target == null)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Dono da propriedade não está online.");
                        break;
                    }

                    if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Dono da propriedade não está próximo de você.");
                        return;
                    }

                    int.TryParse(convite.Valor[0], out int propriedade);
                    int.TryParse(convite.Valor[1], out int valor);
                    if (p.Dinheiro < valor)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui dinheiro suficiente.");
                        break;
                    }

                    var prop = Global.Propriedades.FirstOrDefault(x => x.Codigo == propriedade);
                    if (prop == null)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Propriedade inválida!");
                        break;
                    }

                    if (player.Position.Distance(new Position(prop.EntradaPosX, prop.EntradaPosY, prop.EntradaPosZ)) > Global.DistanciaRP)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está próximo da propriedade.");
                        return;
                    }

                    p.Dinheiro -= valor;
                    p.SetDinheiro();
                    target.Dinheiro += valor;
                    target.SetDinheiro();

                    prop.Personagem = p.Codigo;

                    using (var context = new DatabaseContext())
                    {
                        context.Propriedades.Update(prop);
                        context.SaveChanges();
                    }

                    Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você comprou a propriedade {prop.Codigo} de {target.NomeIC} por ${valor:N0}.");
                    Functions.EnviarMensagem(target.Player, TipoMensagem.Sucesso, $"Você vendeu a propriedade {prop.Codigo} para {p.NomeIC} por ${valor:N0}.");
                    break;
                case TipoConvite.Revista:
                    if (target == null)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Solicitante da revista não está online.");
                        break;
                    }

                    if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Solicitante da revista não está próximo de você.");
                        return;
                    }

                    Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você aceitou ser revistado.");
                    Functions.EnviarMensagem(target.Player, TipoMensagem.Titulo, $"Revista em {p.NomeIC}");
                    Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Celular: {p.Celular} | Dinheiro: ${p.Dinheiro:N0}");
                    if (p.CanalRadio > -1)
                        Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Canal Rádio 1: {p.CanalRadio} | Canal Rádio 2: {p.CanalRadio2} | Canal Rádio 3: {p.CanalRadio3}");
                    foreach (var x in p.Armas)
                        Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Arma: {(WeaponModel)x.Codigo} | Munição: {x.Municao}");
                    break;
                case TipoConvite.VendaVeiculo:
                    if (target == null)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Dono do veículo não está online.");
                        break;
                    }

                    if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Dono do veículo não está próximo de você.");
                        return;
                    }

                    int.TryParse(convite.Valor[0], out int veiculo);
                    int.TryParse(convite.Valor[1], out int valorVeh);

                    if (p.Dinheiro < valorVeh)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui dinheiro suficiente.");
                        break;
                    }

                    var veh = Global.Veiculos.FirstOrDefault(x => x.Codigo == veiculo);
                    if (veh == null)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Propriedade inválida.");
                        break;
                    }

                    if (player.Position.Distance(veh.Vehicle.Position) > Global.DistanciaRP)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está próximo do veículo.");
                        return;
                    }

                    p.Dinheiro -= valorVeh;
                    p.SetDinheiro();
                    target.Dinheiro += valorVeh;
                    target.SetDinheiro();

                    veh.Personagem = p.Codigo;

                    using (var context = new DatabaseContext())
                    {
                        context.Veiculos.Update(veh);
                        context.SaveChanges();
                    }

                    Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você comprou o veículo {veh.Codigo} de {target.NomeIC} por ${valorVeh:N0}.");
                    Functions.EnviarMensagem(target.Player, TipoMensagem.Sucesso, $"Você vendeu o veículo {veh.Codigo} para {p.NomeIC} por ${valorVeh:N0}.");
                    break;
                case TipoConvite.LocalizacaoCelular:
                    float.TryParse(convite.Valor[0], out float posX);
                    float.TryParse(convite.Valor[1], out float posY);

                    player.Emit("Server:SetWaypoint", posX, posY);
                    Functions.EnviarMensagem(player, TipoMensagem.Nenhum, $"[CELULAR] A posição recebida foi marcada no GPS.", Global.CorCelularSecundaria);
                    break;
            }

            p.Convites.RemoveAll(x => x.Tipo == (TipoConvite)tipo);
        }

        [Command("recusar", "/recusar (tipo)", Alias = "rc")]
        public void CMD_recusar(IPlayer player, int tipo)
        {
            if (!Enum.IsDefined(typeof(TipoConvite), tipo))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Tipo inválido.");
                return;
            }

            var p = Functions.ObterPersonagem(player);
            var convite = p.Convites.FirstOrDefault(x => x.Tipo == (TipoConvite)tipo);
            if (convite == null)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Você não possui nenhum convite do tipo {tipo}.");
                return;
            }

            var target = Global.PersonagensOnline.FirstOrDefault(x => x.Codigo == convite.Personagem);
            var strPlayer = string.Empty;
            var strTarget = string.Empty;

            switch ((TipoConvite)tipo)
            {
                case TipoConvite.Faccao:
                    strPlayer = strTarget = "entrar na facção";
                    break;
                case TipoConvite.VendaPropriedade:
                    strPlayer = "compra da propriedade";
                    strTarget = "venda da propriedade";
                    break;
                case TipoConvite.VendaVeiculo:
                    strPlayer = "compra de veículo";
                    strTarget = "venda de veículo";
                    break;
                case TipoConvite.Revista:
                    strPlayer = strTarget = "revista";
                    break;
                case TipoConvite.LocalizacaoCelular:
                    strPlayer = strTarget = "envio de localização";
                    break;
            }

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você recusou o convite para {strPlayer}.");

            if (target != null)
                Functions.EnviarMensagem(target.Player, TipoMensagem.Sucesso, $"{p.NomeIC} recusou seu convite para {strTarget}.");

            p.Convites.RemoveAll(x => x.Tipo == (TipoConvite)tipo);
        }

        [Command("pagar", "/pagar (ID ou nome) (valor)")]
        public void CMD_pagar(IPlayer player, string idNome, int valor)
        {
            var p = Functions.ObterPersonagem(player);

            if (valor <= 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Valor inválido.");
                return;
            }

            if (p.Dinheiro < valor)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui dinheiro suficiente.");
                return;
            }

            var target = Functions.ObterPersonagemPorIdNome(player, idNome, false);
            if (target == null)
                return;

            if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Jogador não está próximo de você.");
                return;
            }

            p.Dinheiro -= valor;
            target.Dinheiro += valor;
            p.SetDinheiro();
            target.SetDinheiro();

            Functions.EnviarMensagem(target.Player, TipoMensagem.Sucesso, $"{p.NomeIC} te deu ${valor:N0}.");
            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você deu ${valor:N0} para {target.NomeIC}.");
            Functions.GravarLog(TipoLog.Dinheiro, $"/pagar {valor}", p, target);
        }

        [Command("revistar", "/revistar (ID ou nome)")]
        public void CMD_revistar(IPlayer player, string idNome)
        {
            var p = Functions.ObterPersonagem(player);

            var target = Functions.ObterPersonagemPorIdNome(player, idNome, false);
            if (target == null)
                return;

            if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Jogador não está próximo de você.");
                return;
            }

            var convite = new Convite()
            {
                Tipo = TipoConvite.Revista,
                Personagem = p.Codigo,
            };
            target.Convites.RemoveAll(x => x.Tipo == TipoConvite.Revista);
            target.Convites.Add(convite);

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você solicitou uma revista para {target.NomeIC}.");
            Functions.EnviarMensagem(target.Player, TipoMensagem.Sucesso, $"Solicitou uma revista em você. (/ac {(int)convite.Tipo} para aceitar ou /rc {(int)convite.Tipo} para recusar)");
        }

        [Command("multas")]
        public void CMD_multas(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Banco && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em um banco.");
                return;
            }

            using var context = new DatabaseContext();
            var multas = context.Multas.AsQueryable().Where(x => !x.DataPagamento.HasValue && x.PersonagemMultado == p.Codigo).OrderBy(x => x.Data).Select(x => new
            {
                x.Codigo,
                x.Motivo,
                Data = x.Data.ToString("dd/MM/yyyy HH:mm:ss"),
                Valor = $"${x.Valor:N0}",
            }).ToList();

            if (multas.Count == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui multas pendentes.");
                return;
            }

            player.Emit("Server:AbrirMultas", JsonConvert.SerializeObject(multas));
        }

        [Command("transferir", "/transferir (ID ou nome) (valor)")]
        public void CMD_transferir(IPlayer player, string idNome, int valor)
        {
            var p = Functions.ObterPersonagem(player);
            if (valor <= 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Valor inválido.");
                return;
            }

            if (p.Banco < valor)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui essa quantia em sua conta bancária.");
                return;
            }

            var target = Functions.ObterPersonagemPorIdNome(player, idNome, false);
            if (target == null)
                return;

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Banco && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP) && p.Celular == 0)
            {
                player.Emit("Server:UsarATM", 1, target.Codigo, valor);
                return;
            }

            Functions.CMDTransferir(player, target.Codigo, valor);
        }

        [Command("sacar", "/sacar (valor)")]
        public void CMD_sacar(IPlayer player, int valor)
        {
            var p = Functions.ObterPersonagem(player);
            if (valor <= 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Valor inválido.");
                return;
            }

            if (p.Banco < valor)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui essa quantia em sua conta bancária.");
                return;
            }

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Banco && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                player.Emit("Server:UsarATM", 2, 0, valor);
                return;
            }

            Functions.CMDSacar(player, valor);
        }

        [Command("depositar", "/depositar (valor)")]
        public void CMD_depositar(IPlayer player, int valor)
        {
            var p = Functions.ObterPersonagem(player);
            if (valor <= 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Valor inválido.");
                return;
            }

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Banco && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em um banco.");
                return;
            }

            if (p.Dinheiro < valor)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui dinheiro suficiente.");
                return;
            }

            p.Dinheiro -= valor;
            p.Banco += valor;
            p.SetDinheiro();

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você depositou ${valor:N0}.");
            Functions.GravarLog(TipoLog.Dinheiro, $"/depositar {valor}", p, null);
        }

        [Command("comprar")]
        public void CMD_comprar(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            if (Global.Pontos.Any(x => x.Tipo == TipoPonto.LojaConveniencia && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                player.Emit("Server:ComprarConveniencia", JsonConvert.SerializeObject(Global.Precos.Where(x => x.Tipo == TipoPreco.Conveniencia).OrderBy(x => x.Nome).Select(x => new
                {
                    x.Nome,
                    Preco = $"${x.Valor:N0}",
                }).ToList()));
                return;
            }

            var prox = Global.Propriedades
                .Where(x => x.Personagem == 0 && player.Position.Distance(new Position(x.EntradaPosX, x.EntradaPosY, x.EntradaPosZ)) <= Global.DistanciaRP)
                .OrderBy(x => player.Position.Distance(new Position(x.EntradaPosX, x.EntradaPosY, x.EntradaPosZ)))
                .FirstOrDefault();
            if (prox != null)
            {
                if (p.Dinheiro < prox.Valor)
                {
                    Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui dinheiro suficiente.");
                    return;
                }

                p.Dinheiro -= prox.Valor;
                prox.Personagem = p.Codigo;

                p.SetDinheiro();
                prox.CriarIdentificador();

                using (var context = new DatabaseContext())
                {
                    context.Propriedades.Update(prox);
                    context.SaveChanges();
                }

                Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você comprou a propriedade por ${prox.Valor:N0}.");
                return;
            }

            var conce = Global.Concessionarias.FirstOrDefault(x => player.Position.Distance(x.PosicaoCompra) <= Global.DistanciaRP);
            if (conce != null)
            {
                var veiculos = Global.Precos.Where(x => x.Tipo == conce.Tipo).OrderBy(x => x.Nome).Select(x => new
                {
                    Nome = x.Nome.ToUpper(),
                    Preco = $"${x.Valor:N0}",
                    Exibicao = Global.VehicleInfos.FirstOrDefault(y => y.Name.ToLower() == x.Nome.ToLower())?.DisplayName ?? string.Empty,
                    Restricao = Functions.VerificarRestricaoVeiculo(x.Nome).Item1,
                }).ToList();

                player.Emit("Server:ComprarVeiculo", conce.Nome, (int)conce.Tipo, JsonConvert.SerializeObject(veiculos));
                return;
            }

            Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está próximo de nenhum ponto de compra.");
        }

        [Command("staff")]
        public void CMD_staff(IPlayer player)
        {
            var players = Global.PersonagensOnline.Where(x => x.UsuarioBD?.Staff > 0).OrderByDescending(x => x.UsuarioBD.Staff).ThenBy(x => x.UsuarioBD.Nome).ToList();
            if (players.Count == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Não há nenhum membro da staff online.");
                return;
            }

            var html = $@"<div class='table-responsive' style='max-height:50vh;overflow-y:auto;overflow-x:hidden;'>
            <table class='table table-bordered table-striped'>
                <thead>
                    <tr class='bg-dark'>
                        <th>Rank</th>
                        <th>Staffer</th>
                        <th class='text-center'>Status</th>
                    </tr>
                </thead>
                <tbody>";

            foreach (var x in players)
            {
                var status = x.EmTrabalhoAdministrativo ? $"<span class='label' style='background-color:{Global.CorSucesso}'>EM SERVIÇO</span>" : $"<span class='label' style='background-color:{Global.CorErro}'>FORA DE SERVIÇO</span>";
                html += $@"<tr><td>{Functions.ObterDisplayEnum(x.UsuarioBD.Staff)}</td><td>{x.UsuarioBD.Nome}</td><td class='text-center'>{status}</td></tr>";
            }

            html += $@"</tbody></table></div>";

            player.Emit("Server:BaseHTML", Functions.GerarBaseHTML($"{Global.NomeServidor} • Staff Online", html));
        }

        [Command("sos", "/sos (mensagem)", GreedyArg = true)]
        public void CMD_sos(IPlayer player, string mensagem)
        {
            var p = Functions.ObterPersonagem(player);
            if (p?.UsuarioBD?.Staff > 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui autorização para usar esse comando.");
                return;
            }

            var sos = Global.SOSs.FirstOrDefault(x => x.IDPersonagem == p.ID);
            if (sos != null)
            {
                var target = sos.Verificar(p.Usuario);
                if (target != null)
                {
                    Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você já possui um SOS pendente de resposta.");
                    return;
                }
            }

            var players = Global.PersonagensOnline.Where(x => x.EmTrabalhoAdministrativo && x.UsuarioBD?.Staff > 0).ToList();
            if (players.Count == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Não há administradores em serviço.");
                return;
            }

            sos = new SOS()
            {
                IDPersonagem = p.ID,
                Mensagem = mensagem,
                Usuario = p.UsuarioBD.Codigo,
                NomePersonagem = p.Nome,
                NomeUsuario = p.UsuarioBD.Nome,
            };

            using (var context = new DatabaseContext())
            {
                context.SOSs.Add(sos);
                context.SaveChanges();
            }

            Global.SOSs.Add(sos);

            foreach (var pl in players)
            {
                Functions.EnviarMensagem(pl.Player, TipoMensagem.Titulo, $"SOS de {p.Nome} [{p.ID}] ({p.UsuarioBD.Nome})");
                Functions.EnviarMensagem(pl.Player, TipoMensagem.Nenhum, mensagem);
            }

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, "SOS enviado para os administradores em serviço.");
        }

        [Command("ferimentos", "/ferimentos (ID ou nome)")]
        public void CMD_ferimentos(IPlayer player, string idNome)
        {
            var target = Functions.ObterPersonagemPorIdNome(player, idNome);
            if (target == null)
                return;

            if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension || target.Ferimentos.Count == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Jogador não está próximo ou não possui ferimentos.");
                return;
            }

            var html = $@"<div class='table-responsive' style='max-height:50vh;overflow-y:auto;overflow-x:hidden;'>
                <table class='table table-bordered table-striped'>
                <thead>
                    <tr>
                        <th>Data</th>
                        <th>Arma</th>
                        <th>Dano</th>
                        <th>Parte do Corpo</th>
                    </tr>
                </thead>
                <tbody>";

            foreach (var x in target.Ferimentos)
            {
                html += $@"<tr><td>{x.Data}</td><td>{(WeaponModel)x.Arma}</td><td>{x.Dano}</td><td>{Functions.ObterParteCorpo(x.BodyPart)}</td></tr>";
            }

            html += $@"
                </tbody>
            </table>
            </div>";

            player.Emit("Server:BaseHTML", Functions.GerarBaseHTML($"Ferimentos de {target.NomeIC}", html));
        }

        [Command("aceitarhospital")]
        public void CMD_aceitarhospital(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            if (p.TimerFerido == null)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está ferido.");
                return;
            }

            if (p.TimerFerido.ElapsedCount == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não pode executar esse comando ainda.");
                return;
            }

            player.Dimension = 0;
            p.Curar();

            foreach (var x in p.Armas)
                player.Emit("RemoveWeapon", x.Codigo);
            p.Armas = new List<Personagem.Arma>();

            foreach (var x in Global.PersonagensOnline.Where(x => x.Player.Dimension == player.Dimension && player.Position.Distance(x.Player.Position) <= 20))
                Functions.EnviarMensagem(x.Player, TipoMensagem.Erro, $"(( {p.NomeIC} [{p.ID}] aceitou tratamento no hospital. ))");

            p.SetPosition(new Position(298.16702f, -584.2286f, 43.24829f), true);
            p.Banco -= Global.Parametros.ValorCustosHospitalares;
            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você aceitou o tratamento e foi levado para o hospital. Os custos hospitalares foram ${Global.Parametros.ValorCustosHospitalares:N0}.");
        }

        [Command("aceitarck")]
        public void CMD_aceitarck(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            if (p.TimerFerido == null)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está ferido.");
                return;
            }

            if (p.TimerFerido.ElapsedCount == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não pode executar esse comando ainda.");
                return;
            }

            p.TimerFerido = null;
            p.DataMorte = DateTime.Now;
            p.MotivoMorte = "Aceitou CK";
            Functions.EnviarMensagemStaff($"{p.Nome} aceitou CK.", true);
            Functions.SalvarPersonagem(p, false);
            Functions.GravarLog(TipoLog.Morte, $"/aceitarck", p, null);
            player.Kick("Você aceitou o CK no seu personagem.");
        }

        [Command("trancar")]
        public void CMD_trancar(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            var prox = Global.Propriedades
                .Where(x => player.Position.Distance(new Position(x.EntradaPosX, x.EntradaPosY, x.EntradaPosZ)) <= Global.DistanciaRP)
                .OrderBy(x => player.Position.Distance(new Position(x.EntradaPosX, x.EntradaPosY, x.EntradaPosZ)))
                .FirstOrDefault();

            if (prox == null)
            {
                prox = Global.Propriedades
                .Where(x => x.Codigo == player.Dimension
                && player.Position.Distance(new Position(x.SaidaPosX, x.SaidaPosY, x.SaidaPosZ)) <= Global.DistanciaRP)
                .OrderBy(x => player.Position.Distance(new Position(x.SaidaPosX, x.SaidaPosY, x.SaidaPosZ)))
                .FirstOrDefault();
            }

            if (prox != null)
            {
                if (prox.Personagem != p.Codigo)
                {
                    Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não é o dono da propriedade.");
                    return;
                }

                Global.Propriedades[Global.Propriedades.IndexOf(prox)].Aberta = !prox.Aberta;
                Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você {(Global.Propriedades[Global.Propriedades.IndexOf(prox)].Aberta ? "des" : string.Empty)}trancou a porta.", notify: true);
                return;
            }

            var veh = Global.Veiculos
                .Where(x => (x.Personagem == p.Codigo || (x.Faccao == p.Faccao && x.Faccao != 0) || x.NomeEncarregado == p.Nome)
                && player.Position.Distance(new Position(x.Vehicle.Position.X, x.Vehicle.Position.Y, x.Vehicle.Position.Z)) <= 5)
                .OrderBy(x => player.Position.Distance(new Position(x.Vehicle.Position.X, x.Vehicle.Position.Y, x.Vehicle.Position.Z)))
                .FirstOrDefault();

            if (veh != null)
            {
                veh.Vehicle.LockState = veh.Vehicle.LockState == VehicleLockState.Locked ? VehicleLockState.Unlocked : VehicleLockState.Locked;
                Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você {(veh.Vehicle.LockState == VehicleLockState.Unlocked ? "des" : string.Empty)}trancou o veículo.", notify: true);
                return;
            }

            Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não tem acesso a nenhuma propriedade ou veículo próximos.");
        }

        [Command("entregararma", "/entregararma (ID ou nome) (arma)")]
        public void CMD_entregararma(IPlayer player, string idNome, string arma)
        {
            var p = Functions.ObterPersonagem(player);
            if (p?.FaccaoBD?.Tipo == TipoFaccao.Policial)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não pode entregar armas estando em uma facção policial.");
                return;
            }

            var wep = Enum.GetValues(typeof(WeaponModel)).Cast<WeaponModel>().FirstOrDefault(x => x.ToString().ToLower() == arma.ToLower());
            if (!p.Armas.Any(x => x.Codigo == (long)wep))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está carregando essa arma.");
                return;
            }

            var target = Functions.ObterPersonagemPorIdNome(player, idNome, false);
            if (target == null)
                return;

            if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Jogador não está próximo de você.");
                return;
            }

            if (target.Armas.Any(x => x.Codigo == (long)wep && x.Municao > 0))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "O jogador já está carregando essa arma.");
                return;
            }

            player.Emit("EntregarArma", target.Codigo, (long)wep);
        }

        [Command("timestamp")]
        public void CMD_timestamp(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            p.UsuarioBD.TimeStamp = !p.UsuarioBD.TimeStamp;
            player.Emit("chat:activateTimeStamp", p.UsuarioBD.TimeStamp);
            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você {(!p.UsuarioBD.TimeStamp ? "des" : string.Empty)}ativou o timestamp do chat.", notify: true);
        }

        [Command("barbearia")]
        public void CMD_barbearia(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Barbearia && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em nenhuma barbearia.");
                return;
            }

            if (p.Dinheiro < Global.Parametros.ValorBarbearia)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Você não possui dinheiro suficiente (${Global.Parametros.ValorBarbearia:N0}).");
                return;
            }

            player.Emit("AbrirBarbeariaMaquiagem", p.InformacoesPersonalizacao, 1);
        }

        [Command("maquiagem")]
        public void CMD_maquiagem(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Barbearia && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em nenhuma barbearia.");
                return;
            }

            if (p.Dinheiro < Global.Parametros.ValorBarbearia)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Você não possui dinheiro suficiente (${Global.Parametros.ValorBarbearia:N0}).");
                return;
            }

            player.Emit("AbrirBarbeariaMaquiagem", p.InformacoesPersonalizacao, 2);
        }

        [Command("roupas")]
        public void CMD_roupas(IPlayer player)
        {
            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.LojaRoupas && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em nenhuma loja de roupas.");
                return;
            }

            var p = Functions.ObterPersonagem(player);
            if (p.Dinheiro < Global.Parametros.ValorRoupas)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Você não possui dinheiro suficiente (${Global.Parametros.ValorRoupas:N0}).");
                return;
            }

            player.Emit("AbrirLojaRoupas", p.InformacoesRoupas, p.InformacoesAcessorios, p.PersonalizacaoDados.sex, p.SlotsRoupas, p.Roupa, 1);
        }

        [Command("mostrarid", "/mostrarid (ID ou nome)")]
        public void CMD_mostrarid(IPlayer player, string idNome)
        {
            var p = Functions.ObterPersonagem(player);
            var target = Functions.ObterPersonagemPorIdNome(player, idNome);
            if (target == null)
                return;

            if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Jogador não está próximo de você.");
                return;
            }

            Functions.EnviarMensagem(target.Player, TipoMensagem.Titulo, $"ID de {p.Nome}");
            Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Nome: {p.Nome}");
            Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Sexo: {(p.PersonalizacaoDados.sex == 1 ? "Homem" : "Mulher")}");
            Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Nascimento: {p.DataNascimento.ToShortDateString()} ({Math.Truncate((DateTime.Now.Date - p.DataNascimento).TotalDays / 365):N0} anos)");
            Functions.SendMessageToNearbyPlayers(player, p == target ? "olha sua própria ID." : $"mostra sua ID para {target.NomeIC}.", TipoMensagemJogo.Ame, 10);
        }

        [Command("dmv")]
        public void CMD_dmv(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);

            if ((p.DataValidadeLicencaMotorista ?? DateTime.MinValue).Date > DateTime.Now && p.PolicialRevogacaoLicencaMotorista == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Sua licença de motorista não vence hoje ou não está revogada.");
                return;
            }

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.DMV && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está na DMV.");
                return;
            }

            var valor = p.DataValidadeLicencaMotorista.HasValue ? Global.Parametros.ValorLicencaMotoristaRenovacao : Global.Parametros.ValorLicencaMotorista;
            if (p.Dinheiro < valor)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Você não possui dinheiro suficiente (${valor:N0}).");
                return;
            }

            p.DataValidadeLicencaMotorista = DateTime.Now.AddMonths(6);
            p.PolicialRevogacaoLicencaMotorista = 0;

            p.Dinheiro -= valor;
            p.SetDinheiro();

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você comprou/renovou sua licença de motorista por ${valor:N0}. A validade é {p.DataValidadeLicencaMotorista?.ToShortDateString()}.");
        }

        [Command("mostrarlicenca", "/mostrarlicenca (ID ou nome)")]
        public void CMD_mostrarlicenca(IPlayer player, string idNome)
        {
            var p = Functions.ObterPersonagem(player);
            if (!p.DataValidadeLicencaMotorista.HasValue)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui uma licença de motorista.");
                return;
            }

            var target = Functions.ObterPersonagemPorIdNome(player, idNome);
            if (target == null)
                return;

            if (player.Position.Distance(target.Player.Position) > Global.DistanciaRP || player.Dimension != target.Player.Dimension)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Jogador não está próximo de você.");
                return;
            }

            Functions.EnviarMensagem(target.Player, TipoMensagem.Titulo, $"Licença de Motorista de {p.Nome}");
            Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Validade: {p.DataValidadeLicencaMotorista?.ToShortDateString()}");
            Functions.EnviarMensagem(target.Player, TipoMensagem.Nenhum, $"Status: {(p.PolicialRevogacaoLicencaMotorista > 0 ? $"{{{Global.CorErro}}}REVOGADA" : (p.DataValidadeLicencaMotorista?.Date >= DateTime.Now.Date ? $"{{{Global.CorSucesso}}}VÁLIDA" : $"{{{Global.CorErro}}}VENCIDA"))}");
            Functions.SendMessageToNearbyPlayers(player, p == target ? "olha sua própria licença de motorista." : $"mostra sua licença de motorista para {target.NomeIC}.", TipoMensagemJogo.Ame, 10);
        }

        [Command("tog", "/tog (tipo)")]
        public void CMD_tog(IPlayer player, string tipo)
        {
            var p = Functions.ObterPersonagem(player);
            switch (tipo.ToLower())
            {
                case "pm":
                    if ((p.UsuarioBD.DataExpiracaoVIP ?? DateTime.MinValue) < DateTime.Now && !p.UsuarioBD.ContentCreator)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Opção disponível apenas para VIP ou criadores de conteúdo.");
                        return;
                    }

                    p.UsuarioBD.TogPM = !p.UsuarioBD.TogPM;
                    Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você {(p.UsuarioBD.TogPM ? "des" : string.Empty)}ativou as mensagens privadas.", notify: true);
                    break;
                case "chatstaff":
                    if (p.UsuarioBD.Staff == TipoStaff.Nenhum)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está na staff.");
                        return;
                    }

                    p.UsuarioBD.TogChatStaff = !p.UsuarioBD.TogChatStaff;
                    Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você {(p.UsuarioBD.TogChatStaff ? "des" : string.Empty)}ativou as mensagens do chat da staff.", notify: true);
                    break;
                case "chatfaccao":
                    if (p.Faccao == 0)
                    {
                        Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em uma facção.");
                        return;
                    }

                    p.UsuarioBD.TogChatFaccao = !p.UsuarioBD.TogChatFaccao;
                    Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você {(p.UsuarioBD.TogChatFaccao ? "des" : string.Empty)}ativou as mensagens do chat da facção.", notify: true);
                    break;
                case "anuncio":
                    p.UsuarioBD.TogAnuncio = !p.UsuarioBD.TogAnuncio;
                    Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você {(p.UsuarioBD.TogAnuncio ? "des" : string.Empty)}ativou as mensagens de anúncios.", notify: true);
                    break;
                default:
                    Functions.EnviarMensagem(player, TipoMensagem.Titulo, "Opções Disponíveis");
                    Functions.EnviarMensagem(player, TipoMensagem.Nenhum, "pm chatstaff chatfaccao anuncio");
                    break;
            }
        }

        [Command("horas")]
        public void CMD_horas(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            var horas = Convert.ToInt32(Math.Truncate(p.TempoConectado / 60M));
            var tempo = 60 - ((horas + 1) * 60 - p.TempoConectado);
            Functions.EnviarMensagem(player, TipoMensagem.Nenhum, $"{{{Global.CorPrincipal}}}{tempo} {{#FFFFFF}}de {{{Global.CorPrincipal}}}60 {{#FFFFFF}}minutos para o próximo pagamento.");
            player.Emit("displayAdvancedNotification", $"SV-RP | {DateTime.Now}");
        }

        [Command("telapreta")]
        public void CMD_telapreta(IPlayer player) => player.Emit("chat:toggleTelaPreta");

        [Command("telacinza")]
        public void CMD_telacinza(IPlayer player) => player.Emit("chat:toggleTelaCinza");

        [Command("telalaranja")]
        public void CMD_telalaranja(IPlayer player) => player.Emit("chat:toggleTelaLaranja");

        [Command("telaverde")]
        public void CMD_telaverde(IPlayer player) => player.Emit("chat:toggleTelaVerde");

        [Command("limparchat")]
        public void CMD_limparchat(IPlayer player) => player.Emit("chat:clearMessages");

        [Command("dl")]
        public void CMD_dl(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            p.DL = !p.DL;
            player.Emit("dl:Config", p.DL);
        }

        [Command("mecurar")]
        public void CMD_mecurar(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            if (!p.Ferido)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está ferido.");
                return;
            }

            var valor = Global.Parametros.ValorCustosHospitalares / 2;
            if (p.Dinheiro < valor)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, $"Você não possui dinheiro suficiente (${valor:N0}).");
                return;
            }

            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.MeCurar && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em um hospital.");
                return;
            }

            player.Emit("Server:freezeEntityPosition", true);
            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Aguarde 5 segundos.");
            AltAsync.Do(async () =>
            {
                await Task.Delay(5000);
                p.Curar();
                p.Dinheiro -= valor;
                p.SetDinheiro();
                player.Emit("Server:freezeEntityPosition", false);
                Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você tratou seus ferimentos por ${valor:N0}.");
            });
        }

        [Command("mascara")]
        public void CMD_mascara(IPlayer player)
        {
            var p = Functions.ObterPersonagem(player);
            if (p.Mascara == 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui uma máscara.");
                return;
            }

            p.UsandoMascara = !p.UsandoMascara;
            p.SetNametag();
            Functions.SendMessageToNearbyPlayers(player, $"{(p.UsandoMascara ? "coloca" : "retira")} sua máscara.", TipoMensagemJogo.Ame, 10);
        }

        [Command("depositarpoupanca", "/depositarpoupanca")]
        public void CMD_depositarpoupanca(IPlayer player)
        {
            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Banco && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em um banco.");
                return;
            }

            var p = Functions.ObterPersonagem(player);
            if (p.Dinheiro < 50000)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui dinheiro suficiente ($50.000).");
                return;
            }

            if (p.Poupanca > 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você já possui dinheiro na poupança.");
                return;
            }

            p.Poupanca = 50000;
            p.Dinheiro -= 50000;
            p.SetDinheiro();

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você depositou $50.000 na poupança.");
            Functions.GravarLog(TipoLog.Dinheiro, $"/depositarpoupanca", p, null);
        }

        [Command("sacarpoupanca", "/sacarpoupanca")]
        public void CMD_sacarpoupanca(IPlayer player)
        {
            if (!Global.Pontos.Any(x => x.Tipo == TipoPonto.Banco && player.Position.Distance(new Position(x.PosX, x.PosY, x.PosZ)) <= Global.DistanciaRP))
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não está em um banco.");
                return;
            }

            var p = Functions.ObterPersonagem(player);
            if (p.Poupanca <= 0)
            {
                Functions.EnviarMensagem(player, TipoMensagem.Erro, "Você não possui dinheiro na poupança.");
                return;
            }

            p.Dinheiro += p.Poupanca;
            p.SetDinheiro();

            Functions.EnviarMensagem(player, TipoMensagem.Sucesso, $"Você sacou ${p.Poupanca:N0} da poupança.");
            Functions.GravarLog(TipoLog.Dinheiro, $"/sacarpoupanca {p.Poupanca}", p, null);
            p.Poupanca = 0;
        }

        [Command("save")]
        public void CMD_save(IPlayer player)
        {
            if (player.IsInVehicle)
            {
                player.Emit("alt:log", $"POS: {player.Vehicle.Position.X.ToString().Replace(",", ".")}f, {player.Vehicle.Position.Y.ToString().Replace(",", ".")}f, {player.Vehicle.Position.Z.ToString().Replace(",", ".")}f");
                player.Emit("alt:log", $"ROT: {player.Vehicle.Rotation.Roll.ToString().Replace(",", ".")}f, {player.Vehicle.Rotation.Pitch.ToString().Replace(",", ".")}f, {player.Vehicle.Rotation.Yaw.ToString().Replace(",", ".")}f");
            }
            else
            {
                player.Emit("alt:log", $"POS: {player.Position.X.ToString().Replace(",", ".")}f, {player.Position.Y.ToString().Replace(",", ".")}f, {player.Position.Z.ToString().Replace(",", ".")}f");
                player.Emit("alt:log", $"ROT: {player.Rotation.Roll.ToString().Replace(",", ".")}f, {player.Rotation.Pitch.ToString().Replace(",", ".")}f, {player.Rotation.Yaw.ToString().Replace(",", ".")}f");
            }
        }
    }
}