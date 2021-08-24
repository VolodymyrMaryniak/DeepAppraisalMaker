<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-row>
        <v-col>
          <h1>My quizzes</h1>

          <v-data-table
            :headers="headers"
            :items="quizSummaries"
            hide-default-footer
            :loading="loading"
            class="elevation-1"
          >
            <template v-slot:progress>
              <v-progress-linear color="blue" indeterminate></v-progress-linear>
            </template>
            <template v-slot:[`item.createdAt`]="{ item }">
              <td>{{ item.createdAt | date }}</td>
            </template>
            <template v-slot:[`item.modifiedAt`]="{ item }">
              <td>{{ item.modifiedAt | date }}</td>
            </template>
            <template v-slot:[`item.controls`]="{ item }">
                <v-btn @click="onButtonClick(item)">
                    <v-icon>mdi-square-edit-outline</v-icon>
                </v-btn>
            </template>
          </v-data-table>
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
import { QuizSummary } from '../models/QuizSummary'

export default Vue.extend({
  data() {
    return {
      loading: true,
      showError: false,
      errorMessage: 'Error while loading quizzes.',
      quizSummaries: [] as QuizSummary[],
      headers: [
        { text: 'Name', value: 'name' },
        { text: 'Created', value: 'createdAt' },
        { text: 'Last modification', value: 'modifiedAt' },
        { text: "", value: "controls", sortable: false }
      ]
    }
  },
  methods: {
    async fetchQuizSummaries() {
      try {
        const response = await this.$axios.get<QuizSummary[]>('api/quizzes')
        this.quizSummaries = response.data
      } catch (e) {
        this.showError = true
        this.errorMessage = `Error while loading quizzes: ${e.message}.`
      }
      this.loading = false
    },
    onButtonClick(item: QuizSummary) {
        console.log(item);
        router.push(`quiz-details/${item.id}`);
    }
  },
  async created() {
    await this.fetchQuizSummaries()
  }
})
</script>
