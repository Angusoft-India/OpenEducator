var Course = React.createClass({

    getInitialState: function () {
        return {
            data: []
        }
    },

    componentDidMount: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', '/Course/' + this.props.id + '/json', true);
        xhr.onload = function () {
            var data;

            try {
                data = JSON.parse(xhr.responseText);
                this.setState({ data: data });
            } catch (e) { }
            
        }.bind(this);
        xhr.send();

    },

    render: function () {

        var xData = this.state.data.Contents;

        return (
            <div className="xCourse">
            </div>
        );
    }

});

var Content = React.createClass({
    
    render: function () {

        return (
            <div className="xContent" dangerouslySetInnerHTML={{ __html: this.props.data }}></div>
        );
    }

});

/* ACCORDION THING */

var CourseContents = React.createClass({

    getInitialState: function () {
        return {
            data: JSON.parse(this.props.data),
            level: 0
        }
    },

    componentDidMount: function () {
        
    },

    render: function () {
        return (
            <div className="xContentList">
                <ul className="vertical accordion-menu menu" data-accordion-menu>
                    {
                        this.state.data.Chapters.map(function (val, i) {
                            if (val != undefined) {
                                return <AccordionItem title="Test" level={2} data={val} />
                            }                            
                        })
                    }
                </ul>
            </div>
        );
    }

});

var AccordionItem = React.createClass({

    getInitialState: function () {
        return {
            data: this.props.data
        }
    },

    render: function () {

        console.log(this.props.title + ' || ' + this.state.data);

        return (
            <li>
                <a href="#" className="accordion-title">{this.props.title}</a>
            </li>
        );
    }

});