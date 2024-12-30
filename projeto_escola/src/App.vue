<template>
  <div id="app">
    <nav></nav>
     <router-view :key="$router.fullPath">

     </router-view>
  </div>
</template>

<script>
import Alunos from './components/Alunos/Alunos.vue';
import Professor from './components/Alunos/Professor/Professor.vue';
import Sobre from './components/Alunos/Sobre/Sobre.vue';
import Nav from './components/Nav.vue'

export default {
  name: 'App',
  components: {
    Alunos,
    Professor,
    Sobre,
    Nav
    
  }
}
</script>

<style>
body{
  background-color: #eee;
  display: grid;
  justify-items: center;
}
body, html {
  margin: 0;
  height: 100%;
}
#app {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100%;
}
.btn{
  background-color: #fa4430;
  padding: 10px 20px;
  cursor:pointer;
  border: 2px  #0000;
  color: #fff;
  font-weight: bold;
  border-radius: 5px;


}
.btn:hover{
  text-shadow: 1px 1px 1px #000;
}

table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}
table tr td{
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}
table thead th{
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}


</style>
