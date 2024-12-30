<template>
    <div>
        <titulo :text="'Aluno: ${aluno.nome}'" :btnvoltar="!visualizando">
          <button v-show="visualizando" class="btn btneditar" @click="editar()">Editar</button>
        </titulo>
        
        <table>
            <tbody>
                <tr>
                    <td class="colPequeno">Matrícula:</td>
                    <td>
                        <label>{{ aluno.id }}</label>

                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Nome:</td>
                    <td>
                        <label v-if="visualizando">{{ aluno.nome }}</label>
                        <input v-else v-model="aluno.nome" type="text">
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Data Nascimento:</td>
                    <td>
                        <label v-if="visualizando">{{ aluno.DataNasc }}</label>
                        <input v-else v-model="aluno.DataNasc" type="text">
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Professor:</td>
                    <td>
                        <label>{{ aluno.profesor.nome }}</label>
                        <select v-model="alunos.profesor">
                         <option  v-for="(professor, index) in professores" 
                         :key="index" v-bind:value="professor">
                         {{ professor.nome }}

                         </option>
                           
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
        <div style="margin-top:10px">
            <div v-if="!visualizando">
              <button class="btn btnSalvar" @click="Salvar(aluno)">salvar</button>  
              <button class="btn btnCancelar" @click="Cancelar()">sancelar</button>  
            </div>
        </div>
    </div>

</template>

<script>
import Titulo from '../_share/Titulo'
export default {
    components: {
        Titulo
    },
    data() {
        return {
            profesores: [],
            aluno: {},
            id: this.$route.params.id,
            visualizando:true
        }
    },
    created() {
        this.$http.get("http://localhost:3000/alunos/" + this.id)
            .then(res => res.json())
            .then(aluno => this.aluno = aluno);

        this.$http.get('http://localhost:3000/professores')
            .then(res => res.json())
            .then(professores => this.professores = professores);
    },
    methods: {
       editar(){
          this.visualizando = !this.visualizando;
       },
       salvar(_aluno){
           let _alunoEditar = {
              id: _aluno.id,
              nome: _aluno.nome,
              dataNasc: _aluno.dataNasc,
              professor:_aluno.professor
           }
           this.$http
            .put("http://localhost:3000/alunos/" + _alunoEditar.id, _alunoEditar);

            this.visualizando = !this.visualizando;
       },
       cancelar(){
         this.visualizando = !this.visualizando;
       }
    }
}
</script>

<style scoped>
.btneditar{
    float: right;
    background-color: rgb(76,186,249);
}
.btnSalvar{
    float: right;
    background-color: rgb(76,186,68);
}
.btnCancelar{
    float: left;
    background-color: rgb(249,186,92);
}
.colPequeno{
    width:20%;
    text-align: right;
    background-color: rgb(125, 217, 245);
    font-weight: bold;
}
input, select{
    margin:0px;
    padding: 5px 10px;
    border-radius: 6px;
    border: solid 1px silver;
    width:95%;
}
select{
    height:38px;
    width:100%;
}
</style>