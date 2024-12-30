<template>
    <div>
        <div style="display:flex; width:50%">
            <h2>{{ titulo }}</h2>
            <div clas="voltar">
                <slot></slot>
                <button v-show="btnvoltar" clas="btn btnvoltar" @clik="voltar()">Voltar</button>
            </div>
        </div>

    </div>
</template>

<script>
export default {
    pro: {
        text: String,
        btnvoltar:Boolean
    },
    methods:{
       voltar(){
        this.$router.back();
       } 
    }
}
</script>

<style scoped>
.voltar {
    width: 50%;
    position: absolute;
    margin-top: 15px;
}

.btnvoltar {
    float: right;
    background-color: rgb(199,199,199);

}
</style>