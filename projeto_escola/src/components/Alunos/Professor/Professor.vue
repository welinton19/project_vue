<template>
    <div>
        <Titulo text="Professores" />
        <table>
            <thead>
                <th>Código</th>
                <th>Nome</th>
                <th>Opçoês</th>
            </thead>
            <tbody v-if="Professores.length">
                <tr v-for="(Professor, index) in Professores" :key="index">
                    <td>{{ Professor.id }}</td>

                    <router-link :to="'/alunos/' + Professor.id" tag="td" style="cursor:pointer">
                        {{ Professor.nome }}
                    </router-link>


                    <td>
                      {{ professores.QtdAlunos }}
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
            Professores: [],
            Alunos:[]
        }
    },
    created() {
        this.$http.get('http://localhost:3000/alunos')
         .then(res => res.json())
          .then(alunos => {
           this.alunos = alunos;
           this.carregarProfessores();
    })
    },
    props: {

    },
    methods: {
        pegarQtdAlunosPorPorfessor(){
            this.Professores.forEach((professor,  index) => {
                profesor = {
                    id: professor.id,
                    nome: professor.nome,
                    QtdAlunos: 
                    this.Alunos.filter(aluno => 
                    aluno.professor_id == professor.id).length
                }
                this.Professores[index] = professor;
            });
        },
      carregarProfessores (){
        this.$http.get('http://localhost:3000/professores')
           .then(res => res.json())
           .then(professores => {
            this.professores = professores
            this.pegarQtdAlunosPorProfessor();
        });
      } 
    },

}
</script>

<style scoped></style>