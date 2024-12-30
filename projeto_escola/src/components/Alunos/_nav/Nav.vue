<template>
    <div class="barraTopo">
        <nav class="marginPrincipal">
            <router-link to="/professore">Professore</router-link>
            <router-link to="/alunosall">Alunos</router-link>
            <router-link to="/sobre">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style  scoped>
.barraTopo {
    background-color: rgb(230, 230, 230);
    
}
.marginPrincipal {
    margin: 10px;
}
nav{
    padding: 20px 20px 20px 0px;
}
nav a{
    padding: 10px;
    text-decoration: none;
    background-color: #fff;
    border-radius: 2px;
    margin-right: 15px;
}
</style>