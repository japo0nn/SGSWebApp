<script lang="ts">
</script>

<template>
    <div>
        <h2>Форма с зависимыми списками и Vue.js</h2>

        <form @submit.prevent="saveData">
            <label for="city">Город:</label>
            <select id="city" v-model="formData.city" @change="workshopUpdate">
                <option value="">Выберите город</option>
                <option value="Astana">Астана</option>
                <option value="Almaty">Алматы</option>
                <option value="Shymkent">Шымкент</option>
                <option value="Taraz">Тараз</option>
                <option value="Qyzylorda">Кызылорда</option>
            </select>

            <br><br>

            <label for="workshop">Цех:</label>
            <select id="workshop" v-model="formData.workshop" @change="employeeUpdate">
                <option value="">Выберите цех</option>
                <option v-for="workshop in filteredWorkshops" :key="workshop" :value="workshop">{{ workshop }}</option>
            </select>

            <br><br>

            <label for="employee">Сотрудник:</label>
            <select id="employee" v-model="formData.employee">
                <option value="">Выберите сотрудника</option>
                <option v-for="employee in filteredEmployees" :key="employee" :value="employee">{{ employee }}</option>
            </select>

            <br><br>

            <label for="brigade">Бригада:</label>
            <select id="brigade" v-model="formData.brigade">
                <option value="1">Бригада 1</option>
                <option value="2">Бригада 2</option>
                <option value="3">Бригада 3</option>
            </select>

            <br><br>

            <label for="shift">Смена:</label>
            <select id="shift" v-model="formData.shift">
                <option value="Утренняя">Утренняя</option>
                <option value="Дневная">Дневная</option>
                <option value="Вечерняя">Вечерняя</option>
            </select>

            <br><br>

            <button type="submit">Сохранить в Cookie</button>
        </form>
    </div>
</template>

<script>
  export default {
    data() {
      return {
        formData: {
          city: '',
          workshop: '',
          employee: '',
          brigade: '1',
          shift: 'Утренняя'
        },
        workshops: {
          Astana: ['Астана цех 1', 'Астана цех 2'],
          Almaty: ['Алматы цех 1', 'Алматы цех 2'],
          Shymkent: ['Шымкент цех 1', 'Шымкент цех 2'],
          Taraz: ['Тараз цех'],
          Qyzylorda: ['Кызылорда цех'],
        },
        employees: {
          'Астана цех 1': ['Астана сотрудник 1'],
          'Астана цех 2': ['Астана сотрудник 2'],
          'Алматы цех 1': ['Алматы сотрудник 1'],
          'Алматы цех 2': ['Алматы сотрудник 2'],
          'Шымкент цех 1': ['Шымкент сотрудник 1'],
          'Шымкент цех 2': ['Шымкент сотрудник 2'],
          'Тараз цех': ['Тараз сотрудник'],
          'Кызылорда цех': ['Кызылорда сотрудник']
        }
      };
    },
    computed: {
      filteredWorkshops() {
        return this.formData.city ? this.workshops[this.formData.city] || [] : [
            'Астана цех 1', 
            'Астана цех 2', 
            'Алматы цех 1', 
            'Алматы цех 2', 
            'Шымкент цех 1', 
            'Шымкент цех 2', 
            'Тараз цех', 
            'Кызылорда цех'];
      },
      filteredEmployees() {
        return this.formData.workshop ? this.employees[this.formData.workshop] || [] : [
            'Астана сотрудник 1', 
            'Астана сотрудник 2', 
            'Алматы сотрудник 1', 
            'Алматы сотрудник 2', 
            'Шымкент сотрудник 1', 
            'Шымкент сотрудник 2', 
            'Тараз сотрудник', 
            'Кызылорда сотрудник'];
      }
    },
    methods: {
      workshopUpdate() {
        this.formData.workshop = '';
        this.formData.employee = '';
      },
      employeeUpdate() {
        this.formData.employee = '';
      },
      saveData() {
        const jsonData = JSON.stringify(this.formData);
        document.cookie = `formData=${jsonData}; path=/`;
        alert('Данные сохранены в Cookie!');
      }
    }
  };
</script>