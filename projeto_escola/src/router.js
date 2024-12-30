import Vue from 'vue';
import Router from 'vue-router';
import Alunos from './components/Alunos/Alunos.vue';
import AlunoDetalhe from '.components/Alunos/alunoDetalhe.vue';
import Professor from './components/Alunos/Professor/Professor.vue';
import Sobre from './components/Alunos/Sobre/Sobre.vue';

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/professores',
            name: 'Professor',
            component: Professor
        },
        {
            path: '/alunos/:prof_id',
            name: 'Alunos',
            component: Alunos
        },
        {
            path: '/alunosall',
            name: 'Alunos',
            component: Alunos
        },
        {
            path: '/alunoDetalhe/:id',
            name: 'AlunoDetalhe',
            component: AlunoDetalhe
        },
        {
            path: '/sobre',
            name: 'Sobre',
            component: Sobre
        }
    ]
 });
