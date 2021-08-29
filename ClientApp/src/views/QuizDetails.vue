<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-row>
        <v-col v-if="!loading">
          <v-row class="mb-3">
            <v-col>
              <small>The quiz was created at: {{ quizDetails.createdAt | date }}</small>
            </v-col>
            <v-col>
              <small>Last modification was at: {{ quizDetails.modifiedAt | date }}</small>
            </v-col>
          </v-row>
          <v-row>
            <b-form @submit="onSubmit">
              <v-col md="8" sm="12">
                <b-form-group label="Quiz name:" label-for="quiz-name-input" class="mb-5">
                  <b-form-input
                    id="quiz-name-input"
                    v-model="quizDetails.name"
                    type="text"
                    required
                  ></b-form-input>
                </b-form-group>
              </v-col>

              <div>
                <div v-for="(question, idq) in quizDetails.questions" :key="idq" class="my-2 mx-5">
                  <label v-bind:for="`question-text-input-${idq}`" class="my-2"
                    >Question {{ idq + 1 }}</label
                  >
                  <v-btn icon v-on:click="toggleQuestionExpander(question)" class="float-end">
                    <v-icon>{{ question.expanded ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
                  </v-btn>
                  <b-form-input
                    v-bind:id="`question-text-input-${idq}`"
                    v-model="question.text"
                    type="text"
                    placeholder="Enter question"
                    required
                  >
                  </b-form-input>
                  <div v-show="question.expanded">
                    <div
                      v-for="(option, ido) in question.answerOptions"
                      :key="ido"
                      class="my-2 mx-5"
                    >
                      <v-row>
                        <v-col class="col-1 text-sm-right">
                          <label v-bind:for="`answer-option-input-${idq}-${ido}`"
                            >{{ ido + 1 }})</label
                          >
                        </v-col>
                        <v-col class="col-11">
                          <b-form-input
                            v-bind:id="`answer-option-input-${idq}-${ido}`"
                            v-model="option.text"
                            type="text"
                            placeholder="Enter asnwer option"
                            required
                          ></b-form-input>
                        </v-col>
                      </v-row>
                    </div>
                    <button v-on:click="addAnswerOption(question)" class="btn btn-success ml-2 mt-2">Add asnwer option</button>
                  </div>
                </div>

                <button v-on:click="addQuestion" class="btn btn-success mt-4">Add question</button>
              </div>

              <b-button type="submit" variant="primary" class="float-end mt-3">Submit</b-button>
            </b-form>
          </v-row>
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
import { AnswerOption, Question, QuizDetails } from '../models/QuizDetails'

export default Vue.extend({
  data() {
    return {
      loading: true,
      quizDetails: {} as QuizDetails,
      showError: false,
      errorMessage: 'Error while loading quiz.'
    }
  },
  methods: {
    async fetchQuizDetails() {
      try {
        const quizId = router.currentRoute.params['quizId']
        const response = await this.$axios.get<QuizDetails>(`api/quizzes/${quizId}/details`)
        response.data.questions?.forEach(q => q.expanded = false);
        this.quizDetails = response.data
      } catch (e) {
        this.showError = true
        this.errorMessage = `Error while loading quizzes: ${e.message}.`
      }
      this.loading = false
    },
    addQuestion() {
      this.quizDetails.questions?.push({
        name: '',
        answerOptions: [],
        expanded: false
      } as Question)
    },
    addAnswerOption(question: Question) {
      question.answerOptions?.push({
        text: '',
        isCorrectAnswer: false
      })
    },
    onSubmit() {
      console.log(1)
    },
    toggleQuestionExpander(question: Question) {
      question.expanded = !question.expanded;
    }
  },
  async created() {
    await this.fetchQuizDetails()
  }
})
</script>
