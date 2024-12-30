<template>
  <div>
    <Titulo :text="professorid != undefined ? 'professor:' + professor.nome : 'Todos os alunos'" />
    <div v-if="professor != undefined ">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()">
      <button class="btn btnInput" @click="addAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opçoês</th>
      </thead>
      <tbody v-if="alonos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{ aluno.id }}</td>
          <router-link :to="'/alunoDetalhe/${aluno.id}'" tag="td" style="cursor:pointer">
            {{ aluno.nome }}
          </router-link>
            
          
          <td>
            <button class="btn" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum aluno encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from '../_share/Titulo.vue';

export default {
  components: {
    Titulo
  },
  data() {
    return {
      titulo: 'Alunos',
      professorid: this.$router.params.prof_id,
      professor: {},
      nome: 'Aluno',
      alunos: []
    }
  },
  created() {
    if (thi.porfessorid) {
      this.carregarProfessores();
      this.$http.get("http://localhost:3000/alunos?professor.id=" + this.professorid)
        .then(res => res.json())
        .then(alunos => this.alunos = alunos)
    } else {
      this.$http.get('http://localhost:3000/alunos')
        .then(res => res.json())
        .then(alunos => this.alunos = alunos)
    }

  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        professor: {
            id: this.professor.id,
            nome: this.professor.nome
  
        }
      }
      this.$http.post('http://localhost:3000/alunos', _aluno)
        .then(res => res.json())
        .then(_aluno => {
          this.alunos.push(_aluno);
          this.nome = '';
        });



      this.alunos.push(_aluno);
      this.nome = '';
    },
    remover(aluno) {

      this.$http.delet('http://localhost:3000/alunos/${aluno.id}')
        .then(() => {
          let indice = this.alunos.Indexof(aluno);
          this.alunos.splice(indice, 1);
        })



    },
    carregarProfessores() {
      this.$http.get('http://localhost:3000/professores/' + this.professorid)
        .then(res => res.json())
        .then(professor => {
          this.professor = professor

        });
    }

  }
};
</script>


<style scoped>
input {

  padding: 20px;
  color: #687f7f;
  display: inline;
  border: none;
}

.btnInput {

  border: none;
  background-color: rgb(116, 115, 115);
  padding: 20px;
  display: inline;

}
</style>
