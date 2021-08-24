<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-row>
        <v-col v-if="!loading">
          <p>
            <small>The quiz was created at: {{quizDetails.createdAt | date}}</small>
          </p>
          <p>
            <small>Last modification was at: {{quizDetails.modifiedAt | date}}</small>
          </p>

          <input v-model="quizDetails.name">
        </v-col>
      </v-row>
    </v-slide-y-transition>
    <v-alert :value="showError" type="error" v-text="errorMessage">
      Sorry, something went wrong
    </v-alert>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue'
import router from '../router/index'
import { QuizDetails } from '../models/QuizDetails'

export default Vue.extend({
  data() {
    return {
      loading: true,
      quizDetails: { } as QuizDetails,
      showError: false,
      errorMessage: 'Error while loading quiz.'
    }
  },
  methods: {
    async fetchQuizDetails() {
      try {
        const quizId = router.currentRoute.params['quizId'];
        const response = await this.$axios.get<QuizDetails>(`api/quizzes/${quizId}/details`);
        this.quizDetails = response.data;
      } catch (e) {
        this.showError = true
        this.errorMessage = `Error while loading quizzes: ${e.message}.`
      }
      this.loading = false
    }
  },
  async created() {
    await this.fetchQuizDetails();
  }
})
</script>
