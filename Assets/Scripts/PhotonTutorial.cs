using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class PhotonTutorial : MonoBehaviourPunCallbacks
{
    // Este script foi criado com o intuito de facilitar o entendimento do Photon, entretanto, é apenas o começo! Para poder realmente utilizar todas as funções e possibilidades do Photon, importe a biblioteca deles e estude sobre as outras funções necessárias!
    // Além disso, no relatório desenvolvido por nossa equipe você poderá seguir uma espécie de passo a passo que irá te ajudar a compreender mais sobre o que é necessário para o funcionamento do Photon.
    // Esperamos que este projetinho possa te ajudar a entender o básico do necessário sobre Photon e os componentes de redes!

    //Passo #01!
    //Para criar um jogo multiplayer, será necessário que você se conecte a um servidor, para isso usaremos algumas funções!
    //Essas funções são chamadas partindo das funções do próprio Photon, apenas tornaremos mais intuitivo para o compreendimento.

    public PhotonPT photonPT; // Chamaremos este script criado por nós, para nos ajudar a entender melhor o funcionamento!
    [SerializeField] TMP_InputField CriarSalaComNome;
    [SerializeField] TMP_InputField EntrarEmSalaComNome;
    private void Start()
    {
        photonPT.ConectarUsandoConfigs();
    }

    public override void OnConnectedToMaster() //Alguns códigos não puderam ser traduzidos em virtude da sua funcionalidade estar atrelada diretamente a sua chamada dessa forma. Mas é possível entender ao acessar nosso relatório!
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

   //Passo #02! 
   //Agora precisaremos criar e nos juntar a salas dentro do servidor que entramos!

   public void CriarSala()
   {
        photonPT.CriarSala(CriarSalaComNome.text.ToString());
   }

   public void EntrarSala()
   {
        photonPT.EntrarNaSala(EntrarEmSalaComNome.text.ToString());
   }

    public override void OnJoinedRoom() // Acesse ao relatório para maiores informações, esta função não pôde ser traduzida.
    {
        PhotonNetwork.LoadLevel("Game");
    }

    // Com os códigos acima, é possível acessar ao servidor e criar ou entrar em uma sala existente, porém para que você possa assumir controle do seu personagem e também instanciá-lo, será necessário alguns comandos que irei deixar abaixo!
    //Para instanciar os personagens, precisaremos utilizar uma adaptação do código Instantiate que criamos, usaremos o PhotonNetwork.Instantiate();, acesse o relatório para mais informações.
    //Para detectar o personagem e definir para quem será a movimentação, usaremos o photonView.isMine em uma condicional. Para mais detalhes, acesse o relatório!
}
